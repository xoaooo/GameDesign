using UnityEngine;

public class DropFood : MonoBehaviour
{
    public int meatCharges;
    PlayerStatistics statistics;

    [SerializeField] private AudioClip food;

    private void Start()
    {
        UI.updateMeat(meatCharges);
    }
    private void Awake()
    {
        statistics = FindObjectOfType<PlayerStatistics>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2") && meatCharges > 0)
        {
            GameObject spawner = gameObject.transform.GetChild(1).gameObject;
            spawner.GetComponent<SpawnFood>().SpawnFoodHere();

            SoundFXManager.instance.PlaySFXClip(food, transform, 0.3f);

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
