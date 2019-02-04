using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    public Text waveCountdownText;

    private float countdown = 2f;
    private int waveNumber = 0;

    private void Update()
    {
        if (countdown <= 0)
        {
            StartCoroutine( SpawnWave());
            countdown = timeBetweenWaves;
        }
        else
            waveCountdownText.text = Mathf.Floor(countdown + 1).ToString();

        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        Debug.Log("Wave incoming");
        waveNumber++;
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
