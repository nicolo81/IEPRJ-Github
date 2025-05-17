using UnityEngine;

public class MeleeWep : Weapon
{
    public GameObject slashPrefab;
    public float slashDistance;
    public float slashDuration;

    public override void Use()
    {
        // Spawn the slash at the tip of the weapon
        Vector3 spawnPos = transform.position + transform.right * slashDistance;
        Quaternion spawnRot = transform.rotation;

        GameObject slash = Instantiate(slashPrefab, spawnPos, spawnRot);
        Slash slashScript = slash.GetComponent<Slash>();
        if (slashScript != null)
        {
            Stats playerStats = player.GetComponent<Stats>();
            slashScript.duration = slashDuration;
            if (playerStats != null)
            {
                slashScript.attack = playerStats.atk;
            }
        }

    }
}
