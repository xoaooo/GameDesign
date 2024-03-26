using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    [SerializeField] private List<GameObject> objects;
    void Start()
    {
        int rand = Random.Range(0, objects.Count);
        int spawn = Random.Range(0, 5);
        if (spawn < 3)
            Instantiate(objects[rand], transform.position, Quaternion.identity);
    }
}
