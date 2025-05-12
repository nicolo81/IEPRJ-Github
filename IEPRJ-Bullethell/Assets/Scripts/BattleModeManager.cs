using UnityEngine;

public class BattleModeManager : MonoBehaviour
{
    public GameObject playerPrefab;        
    public GameObject weaponPrefab;
    public GameObject enemyPrefab;

    private Player playerInstance;
    private Enemy enemyInstance;
    void Start()
    {
        // Spawn player
        GameObject playerObj = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        playerInstance = playerObj.GetComponent<Player>();

        // Spawn enemy (we need an enemymanager for this, this is for testing)
        GameObject enemyObj = Instantiate(enemyPrefab, new Vector3(5, 0, 0), Quaternion.identity);
        enemyInstance = enemyObj.GetComponent<Enemy>();

        // Spawn weapon and assign to player
        GameObject weaponObj = Instantiate(weaponPrefab, playerObj.transform.position, Quaternion.identity);
        Weapon weapon = weaponObj.GetComponent<Weapon>();
        if (weapon != null)
        {
            // Try to assign the player field if it exists
            var playerField = weapon.GetType().GetField("player");
            if (playerField != null)
            {
                playerField.SetValue(weapon, playerObj.transform);
            }

            playerInstance.EquipWeapon(weapon);
        }
    }
}
