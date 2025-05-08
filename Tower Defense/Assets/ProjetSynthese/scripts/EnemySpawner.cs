using System.Collections;
using UnityEngine;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyFastPrefab;
    [SerializeField] private GameObject _enemyTankPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _spawnInterval = 0.5f;
    [SerializeField] private Transform _targetFinal;

    [SerializeField] private int _numberOfWaves = 3;
    [SerializeField] private float _pauseBetweenWaves = 5f;
    private int _enemiesPerWave = 10;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI waveText;

    private int _enemiesAlive = 0;
    private bool _toutesLesVaguesTerminees = false;

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        for (int wave = 1; wave <= _numberOfWaves; wave++)
        {
            UpdateWaveText(wave);
            Debug.Log($"--- Vague {wave} ---");

            int enemiesThisWave = _enemiesPerWave * wave;

            for (int i = 0; i < enemiesThisWave; i++)
            {
                SpawnRandomEnemy();
                yield return new WaitForSeconds(_spawnInterval);
            }

            Debug.Log($"Fin de la vague {wave}. Prochaine dans {_pauseBetweenWaves} secondes.");
            yield return new WaitForSeconds(_pauseBetweenWaves);
        }

        UpdateWaveText(-1);
        _toutesLesVaguesTerminees = true;
        Debug.Log("Toutes les vagues sont terminées !");
        CheckVictoryCondition();
    }

    void SpawnRandomEnemy()
    {
        int enemyType = Random.Range(0, 2);
        GameObject prefab = (enemyType == 0) ? _enemyFastPrefab : _enemyTankPrefab;

        GameObject newEnemy = Instantiate(prefab, _spawnPoint.position, _spawnPoint.rotation);

        Enemy enemyScript = newEnemy.GetComponent<Enemy>();
        if (enemyScript != null)
        {
            enemyScript.target = _targetFinal;
            enemyScript.onDeath += OnEnemyKilled;
        }

        _enemiesAlive++;
    }

    void OnEnemyKilled()
    {
        _enemiesAlive--;

        CheckVictoryCondition();
    }

    void CheckVictoryCondition()
    {
        if (_toutesLesVaguesTerminees && _enemiesAlive <= 0 && GameManager.Instance.vieActuelle > 0)
        {
            GameManager.Instance.Victory();
        }
    }

    void UpdateWaveText(int waveNumber)
    {
        if (waveText == null) return;

        if (waveNumber == -1)
            waveText.text = "Toutes les vagues terminées";
        else
            waveText.text = "Vague : " + waveNumber;
    }
}
