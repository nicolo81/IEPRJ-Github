using UnityEngine;

public abstract class Enemy : Stats
{
    // No need for playerTransform field

    // Initialize stats (no player reference needed)
    public void InitEnemy(int hp, int atk, int def, float moveSpeed)
    {
        InitStats(hp, atk, def, moveSpeed);
    }

    protected virtual void Start() { }
    protected virtual void Update()
    {
        MoveTowardsPlayer();

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    // WE NEED TO UPDATE THIS IN THE FUTURE SUCH THAT IT MAKES USE OF NAVMESH TO AVOID OBSTACLES
    protected void MoveTowardsPlayer()
    {
        // Always get the current active player
        Transform playerTransform = BattleModeManager.ActivePlayerTransform;
        if (playerTransform == null)
            return;

        Vector2 direction = (playerTransform.position - transform.position).normalized;
        transform.position += (Vector3)(direction * moveSpeed * Time.deltaTime);
    }

    // Abstract attack method for future enemies such as their own projectiles or an AoE attack
    public abstract void Attack();
}
