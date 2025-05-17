using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public float interval;         // Time between shots (seconds)
    public Transform player;     
    public float orbitRadius = 1f; // Weapon distance from player

    protected virtual void Update()
    {
        if (player == null)
            return;

        // Get mouse position 
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f; 


        Vector2 direction = (mouseWorldPos - player.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Set position to orbit around player
        Vector3 orbitPosition = player.position + (Vector3)(direction * orbitRadius);
        transform.position = orbitPosition;

        // Rotate the weapon to face outward
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public abstract void Use();
}
