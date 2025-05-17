using UnityEngine;

public class TempWep : Weapon
{
    public GameObject projectilePrefab;
    public float projectileSpeed;  // Projectile speed
    public override void Use()
    {
        Vector2 direction = transform.right;
        GameObject proj = Instantiate(projectilePrefab, transform.position, transform.rotation);
        Projectile projectileScript = proj.GetComponent<Projectile>();
        if (projectileScript != null)
        {
            Stats playerStats = player.GetComponent<Stats>();
            if (playerStats != null)
            {
                projectileScript.attack = playerStats.atk;
            }
        }
        Rigidbody2D rb = proj.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = direction * projectileSpeed;
        }
    }

}
