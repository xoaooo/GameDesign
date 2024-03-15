using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private float countdown = 2f;
    public GameObject enemyPrefab;

    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave()); // Start the coroutine when countdown reaches zero
            countdown = 2f; // Reset countdown for the next wave
        }
        else
        {
            countdown -= Time.deltaTime; // Decrement countdown by deltaTime each frame
        }
    }

    private IEnumerator SpawnWave()
    {
        GameObject enemy = Instantiate(enemyPrefab, transform.position, transform.rotation);
        enemy.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        yield return new WaitForSeconds(1f); // Wait for 1 second before completing the coroutine
    }
}
