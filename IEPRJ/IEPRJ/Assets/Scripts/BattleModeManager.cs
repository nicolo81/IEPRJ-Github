using UnityEngine;

public class BattleModeManager : MonoBehaviour
{
    public GameObject[] characterPrefabs; // Assign two character prefabs in Inspector
    public GameObject weaponPrefab;
    public GameObject weapon2Prefab;
    public GameObject enemySwarmManagerPrefab;

    private GameObject[] characters = new GameObject[2];
    private Weapon[] weapons = new Weapon[2];
    private int activeIndex = 0;
    private EnemySwarmManager enemySwarmManagerInstance;
    public static Transform ActivePlayerTransform { get; private set; }

    void Start()
    {
        // Instantiate both characters, set inactive immediately
        characters[0] = Instantiate(characterPrefabs[0], Vector3.zero, Quaternion.identity);
        characters[1] = Instantiate(characterPrefabs[1], Vector3.zero, Quaternion.identity);

        characters[0].SetActive(false);
        characters[1].SetActive(false);

        // Equip weapons
        GameObject weaponObj = Instantiate(weaponPrefab, characters[0].transform.position, Quaternion.identity);
        weapons[0] = weaponObj.GetComponent<Weapon>();
        if (weapons[0] != null)
        {
            var playerField = weapons[0].GetType().GetField("player");
            if (playerField != null)
                playerField.SetValue(weapons[0], characters[0].transform);
            characters[0].GetComponent<Player>().EquipWeapon(weapons[0]);
        }

        GameObject weaponObj2 = Instantiate(weapon2Prefab, characters[1].transform.position, Quaternion.identity);
        weapons[1] = weaponObj2.GetComponent<Weapon>();
        if (weapons[1] != null)
        {
            var playerField = weapons[1].GetType().GetField("player");
            if (playerField != null)
                playerField.SetValue(weapons[1], characters[1].transform);
            characters[1].GetComponent<Player>().EquipWeapon(weapons[1]);
        }

        // Activate only the first character and its weapon
        SetActiveCharacter(0);

        // Set the static active player reference after initial activation
        ActivePlayerTransform = characters[activeIndex].transform;

        // Spawn EnemySwarmManager and set the player reference to the active character
        if (enemySwarmManagerPrefab != null)
        {
            GameObject swarmManagerObj = Instantiate(enemySwarmManagerPrefab, Vector3.zero, Quaternion.identity);
            enemySwarmManagerInstance = swarmManagerObj.GetComponent<EnemySwarmManager>();
            if (enemySwarmManagerInstance != null)
            {
                enemySwarmManagerInstance.SetPlayer(characters[activeIndex].transform);
            }
        }
    }


    public void SwapActiveCharacter()
    {
        int nextIndex = (activeIndex + 1) % characters.Length;
        SetActiveCharacter(nextIndex);
    }

    private void SetActiveCharacter(int index)
    {
        int prevIndex = activeIndex;
        activeIndex = index;

        // Move the new active character to the previous active character's position
        characters[activeIndex].transform.position = characters[prevIndex].transform.position;

        for (int i = 0; i < characters.Length; i++)
        {
            bool isActive = (i == activeIndex);
            if (characters[i] != null)
                characters[i].SetActive(isActive);
            if (weapons[i] != null)
                weapons[i].gameObject.SetActive(isActive);
        }

        // Update enemy manager to follow the new active character
        if (enemySwarmManagerInstance != null)
            enemySwarmManagerInstance.SetPlayer(characters[activeIndex].transform);

        // Update static reference for enemies
        ActivePlayerTransform = characters[activeIndex].transform;
    }
}
