using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyFastPrefab;
    [SerializeField] private GameObject _enemyTankPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _spawnInterval = 3f; 

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true) 
        {
            yield return new WaitForSeconds(_spawnInterval);

            int enemyType = Random.Range(0, 2); 
            GameObject enemyToSpawn = (enemyType == 0) ? _enemyFastPrefab : _enemyTankPrefab;

            Instantiate(enemyToSpawn, _spawnPoint.position, _spawnPoint.rotation);
        }
    }
}
