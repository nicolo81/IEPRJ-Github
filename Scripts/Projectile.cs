using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int attack; 

    void Start()
    {
        Destroy(gameObject, 2f); // Destroy after 2 seconds
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("enemy found");
            Stats enemyStats = other.GetComponentInParent<Stats>();
            if (enemyStats != null)
            {
                enemyStats.hp -= attack;
                Debug.Log($"hit enemy for {attack}");
            }
        }
        Destroy(gameObject);
    }

}
