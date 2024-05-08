using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBone : MonoBehaviour
{
    [SerializeField] private GameObject bone;
    public int meatCharges;

    AudioManager audioManager;

    private void Start()
    {
        UI.updateMeat(meatCharges);
    }
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if (meatCharges > 0)
            {
                meatCharges--;
                UI.updateMeat(meatCharges);
                GameObject spawner = gameObject.transform.GetChild(1).gameObject;
                spawner.GetComponent<SpawnFood>().SpawnFoodHere();
                //Instantiate(bone, transform.position, transform.rotation);
                audioManager.PlaySFX(audioManager.meat);
            }

        }
    }

    public void AddMeatCharge()
    {
        meatCharges++;
        UI.updateMeat(meatCharges);
    }
}
