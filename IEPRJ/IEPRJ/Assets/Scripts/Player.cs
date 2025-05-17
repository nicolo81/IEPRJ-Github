using UnityEngine;

public abstract class Player : Stats
{
    public Weapon weapon;
    private Rigidbody2D rb;
    private float weaponIntervals = 0f;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MovePlayer();

        if (weapon != null)
        {
            weaponIntervals += Time.deltaTime;
            if (weaponIntervals >= weapon.interval)
            {
                UseWeapon();
                weaponIntervals = 0f;
            }
        }

        // Handle character swap input here
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Find the manager and swap character
            var manager = Object.FindFirstObjectByType<BattleModeManager>();
            if (manager != null)
            {
                manager.SwapActiveCharacter();
                UseUltimate();
            }
        }
    }

    void MovePlayer()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(moveX, moveY).normalized * moveSpeed;
        rb.linearVelocity = movement;

    }

    public void EquipWeapon(Weapon newWeapon)
    {
        weapon = newWeapon;

        if (weapon is TempWep tempWep)
        {
            tempWep.player = this.transform;
        }
    }

    public void UseWeapon()
    {
        if (weapon != null)
            weapon.Use();
    }

    // Abstract method for ultimate ability
    public abstract void UseUltimate();
}
