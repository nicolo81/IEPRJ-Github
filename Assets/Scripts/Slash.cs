using UnityEngine;

public class Slash : MonoBehaviour
{
    public int attack;
    public int meelewepatk;
    public float duration;
    void Start()
    {
        Destroy(gameObject, duration);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("enemy found");
            Stats enemyStats = other.GetComponentInParent<Stats>();
            if (enemyStats != null)
            {
                enemyStats.hp -= attack * meelewepatk;
                Debug.Log($"hit enemy for {attack * meelewepatk}");
            }
        }
    }
}
