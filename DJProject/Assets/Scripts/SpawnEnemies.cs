using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public float enemyScale, waveTime, respawnTime, countdown;
    public int waveNumber = 1;
    public int waveStatus = 0; // 0 - Pick enemies; 1- Spawn enemies; 2 - End Wave
    public GameObject[] enemySpawners;
    PlayerStatistics statistics;
    private void Awake()
    {
        statistics = FindObjectOfType<PlayerStatistics>();
    }
    // Update is called once per frame
    void Update()
    {
        if (waveStatus == 0)
        {
            waveStatus = 1;
        }

        if (waveStatus == 1)
        {
            if (countdown <= 0f)
            {
                foreach (var spawner in enemySpawners)
                {
                    StartCoroutine(spawner.GetComponent<WaveSpawner>().SpawnEnemy());
                }
                countdown = respawnTime;
            }

            waveTime -= Time.deltaTime;
            countdown -= Time.deltaTime;

            if (waveTime <= 0)
            {
                waveStatus = 2;
                var enemies = GameObject.FindGameObjectsWithTag("Enemy");
                foreach (var enemy in enemies)
                {
                    Destroy(enemy);
                }
                UI.enableWaveCanvas();
                //start store menu or something
                //waveStatus = 0 when leaving menu
            }
        }

    }

    public int NextWave()
    {
        this.waveNumber++;
        statistics.IncrementWave();
        return this.waveNumber;
    }
}
