using UnityEngine;

public class Player : Stats
{
    public Weapon weapon;
    private Rigidbody2D rb;

    private float weaponIntervals = 0f;

    public Player(int hp, int atk, int def, float moveSpeed)
    {
        InitStats(hp, atk, def, moveSpeed);
    }

    void Start()
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
}
