using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private float countdown = 2f;
    public float enemyScale;
    public GameObject enemyPrefab;

    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = 2f;
        }
        else
        {
            countdown -= Time.deltaTime;
        }
    }

    private IEnumerator SpawnWave()
    {
        GameObject enemy = Instantiate(enemyPrefab, transform.position, transform.rotation);
        enemy.transform.localScale = new Vector3(enemyScale, enemyScale, enemyScale);
        yield return new WaitForSeconds(1f);
    }
}
