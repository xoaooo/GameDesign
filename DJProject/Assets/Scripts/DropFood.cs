using UnityEngine;

public class DropFood : MonoBehaviour
{
    public int meatCharges;
    PlayerStatistics statistics;

    AudioManager audioManager;

    private void Start()
    {
        UI.updateMeat(meatCharges);
    }
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        statistics = FindObjectOfType<PlayerStatistics>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2") && meatCharges > 0)
        {
            GameObject spawner = gameObject.transform.GetChild(1).gameObject;
            spawner.GetComponent<SpawnFood>().SpawnFoodHere();
            audioManager.PlaySFX(audioManager.meat);
            meatCharges--;
            UI.updateMeat(meatCharges);
            statistics.abilityCount++;


        }
    }

    public void AddMeatCharge()
    {
        meatCharges++;
        UI.updateMeat(meatCharges);
    }
}
