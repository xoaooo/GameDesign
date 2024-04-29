using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBone : MonoBehaviour
{
    [SerializeField] private GameObject bone;

    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2")) 
        {
            
            Instantiate(bone, transform.position, transform.rotation);
            audioManager.PlaySFX(audioManager.meat);
            

        }
    }
   
}
