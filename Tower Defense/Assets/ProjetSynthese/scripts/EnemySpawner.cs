using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyFastPrefab;
    [SerializeField] private GameObject _enemyTankPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _spawnInterval = 1f;
    [SerializeField] private float _pauseBetweenWaves = 5f;
    [SerializeField] private Transform _targetFinal;

    private int _waveNumber = 0;
    private int _enemiesPerWave = 3;

    void Start()
    {
        StartCoroutine(LaunchWaves());
    }

    IEnumerator LaunchWaves()
    {
        while (true)
        {
            _waveNumber++;
            int totalEnemies = _enemiesPerWave + _waveNumber;

            Debug.Log($"Vague {_waveNumber} : {totalEnemies} ennemis");

            for (int i = 0; i < totalEnemies; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(_spawnInterval);
            }

            yield return new WaitForSeconds(_pauseBetweenWaves);
        }
    }

    void SpawnEnemy()
    {
        int enemyType = Random.Range(0, 2);
        string poolTag = (enemyType == 0) ? "EnemyFast" : "EnemyTank";

        GameObject enemy = ObjectPoolManager.Instance.GetFromPool(poolTag, _spawnPoint.position, Quaternion.identity);
        if (enemy != null)
        {
            enemy.SetActive(true);
            Enemy enemyScript = enemy.GetComponent<Enemy>();
            if (enemyScript != null)
            {
                enemyScript.target = _targetFinal;
                enemyScript._vie += 10f * (_waveNumber - 1);
            }
        }
    }
}
