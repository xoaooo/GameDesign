using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    public GameObject food;
    
    public void SpawnFoodHere()
    {
        Instantiate(food, transform.position, transform.rotation);
    }
}
