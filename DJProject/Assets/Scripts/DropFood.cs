using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBone : MonoBehaviour
{
    [SerializeField] private GameObject bone;
    void Update()
    {
        if (Input.GetButtonDown("Fire2")) 
        {
            Instantiate(bone, transform.position, transform.rotation);
        }
    }
}
