using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public float enemyScale, waveTime, respawnTime, countdown;
    public static int waveNumber = 0;
    private int waveStatus = 0; // 0 - Pick enemies; 1- Spawn enemies; 2 - End Wave
    public GameObject[] enemySpawners;

    // Update is called once per frame
    void Update()
    {
        if (waveStatus == 0)
        {
            waveNumber++;
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
                /*waveTime += 10f;
                countdown -= 0.5f;
                respawnTime -= 0.5f;*/
                
                //start store menu or something
                //waveStatus = 0 when leaving menu
            }
        }

    }
}
