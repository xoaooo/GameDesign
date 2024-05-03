using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject[] enemies;
    private GameObject enemy, waveSpawner;


    private void Start()
    {
        waveSpawner = GameObject.FindGameObjectWithTag("WaveSpawner");
    }
    void Update()
    {
        enemy = enemies[Random.Range(0, enemies.Length)];        
    }

    public IEnumerator SpawnEnemy()
    {
        Instantiate(enemy, transform.position, transform.rotation);
        yield return new WaitForSeconds(waveSpawner.GetComponent<SpawnEnemies>().respawnTime);
    }
}
