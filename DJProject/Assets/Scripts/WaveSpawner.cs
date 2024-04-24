using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private float countdown = 2f;
    [SerializeField] private float respawnTime = 2f;
    public float enemyScale;
    public static int waveNumber = 0;
    private int waveStatus = 0; // 0 - Pick enemies 1- Spawn enemies 2 - End Wave
    public GameObject[] enemies;
    private GameObject enemy;
    public float waveTime;

    void Update()
    {
        if (waveStatus == 0) 
        {
            waveNumber++;
            enemy = enemies[Random.Range(0, enemies.Length)];
            waveStatus = 1;
        }
        
        if(waveStatus == 1)
        {
            if (countdown <= 0f)
            {
                StartCoroutine(SpawnWave());
                countdown = respawnTime;
            }
            waveTime -= Time.deltaTime;
            countdown -= Time.deltaTime;

            if (waveTime <= 0)
            {
                waveStatus = 2;
                //start store menu or something
                //waveStatus = 0 when leaving menu
            }
        }           
    }

    private IEnumerator SpawnWave()
    {
        Instantiate(enemy, transform.position, transform.rotation);
        yield return new WaitForSeconds(1f);
    }
}
