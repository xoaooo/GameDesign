using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawn : MonoBehaviour
{
    [SerializeField] private List<GameObject> objects;
    void Start()
    {
        int rand = Random.Range(0, objects.Count);
        int spawn = Random.Range(0, 10);
        if (spawn < 3)
            Instantiate(objects[rand], transform.position, Quaternion.identity);
    }
}

