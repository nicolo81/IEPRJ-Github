using UnityEngine;

public class EnemySwarmManager : MonoBehaviour
{
    public GameObject basicEnemyPrefab;
    public GameObject fastEnemyPrefab;
    public GameObject tankEnemyPrefab;
    public float spawnRadius = 10f;
    public float spawnInterval = 2f;

    private Transform playerTransform;
    private float spawnTimer;

    public void SetPlayer(Transform player)
    {
        playerTransform = player;
    }

    void Start()
    {
        spawnTimer = spawnInterval;
    }

    void Update()
    {
        if (playerTransform == null || basicEnemyPrefab == null || fastEnemyPrefab == null || tankEnemyPrefab == null)
            return;

        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0f)
        {
            SpawnEnemy();
            spawnTimer = spawnInterval;
        }
    }

    void SpawnEnemy()
    {
        // Pick a random angle in radians
        float angle = Random.Range(0f, Mathf.PI * 2f);
        Vector3 spawnPos = playerTransform.position + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * spawnRadius;

        int randEnemy = Random.Range(0, 3);

        if (randEnemy == 0)
        {
            GameObject basicEnemyObj = Instantiate(basicEnemyPrefab, spawnPos, Quaternion.identity);
        } else if (randEnemy == 1)
        {
            GameObject fastEnemyObj = Instantiate(fastEnemyPrefab, spawnPos, Quaternion.identity);
        } else
        {
            GameObject tankEnemyObj = Instantiate(tankEnemyPrefab, spawnPos, Quaternion.identity);
        }


    }
}
