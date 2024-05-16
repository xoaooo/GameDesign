using UnityEngine;

public class PowerUpSpawn : MonoBehaviour
{
    public GameObject[] objects;
    public GameObject[] positions;
    void Start()
    {
        CreateSpawnPowerUps(objects, positions);
        Debug.Log(objects.Length);
    }


    public void CreateSpawnPowerUps(GameObject[] objects, GameObject[] positions)
    {
        Debug.Log(positions.Length);
        var existingPowerUps = GameObject.FindGameObjectsWithTag("PowerUp");
        foreach (var powerUp in existingPowerUps)
        {
            Destroy(powerUp);
        }
        foreach (var position in positions)
        {
            int rand = Random.Range(0, objects.Length);
            int spawn = Random.Range(0, 10);
            if (spawn < 3)
                Instantiate(objects[rand], position.transform.position, Quaternion.identity);
        }
    }
}