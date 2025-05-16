using UnityEngine;

public abstract class Enemy : Stats
{
    protected Transform playerTransform;

    // Initialize stats and set player reference
    public void InitEnemy(int hp, int atk, int def, float moveSpeed, Transform player)
    {
        InitStats(hp, atk, def, moveSpeed);
        playerTransform = player;
    }

    protected virtual void Start()
    {
        // Find the player in the scene if not set
        if (playerTransform == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
                playerTransform = playerObj.transform;
        }
    }

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
        if (playerTransform == null)
            return;

        Vector2 direction = (playerTransform.position - transform.position).normalized;
        transform.position += (Vector3)(direction * moveSpeed * Time.deltaTime);
    }

    // Abstract attack method for future enemies such as their own projectiles or an AoE attack
    public abstract void Attack();
}
