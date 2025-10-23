using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public float spawnInterval = 6f;
    public Transform spawnPoint; // assign in Inspector instead of manually setting spawnX/spawnY

    [Header("Pooling Reference")]
    public ObjectPooler pooler; // assign ObjectPooler in Inspector

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    private void SpawnEnemy()
    {
        if (pooler == null || spawnPoint == null)
            return;

        pooler.SpawnFromPool("Enemy", spawnPoint.position, Quaternion.identity);
    }
}
