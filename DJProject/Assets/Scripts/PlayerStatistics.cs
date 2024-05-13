using UnityEngine;

public class PlayerStatistics : MonoBehaviour
{
    public static int god = 0, meat = 0, coins = 0, dashes = 0, pickup = 0, wave = 0;
    public static float gameTime = 0f;
    // Update is called once per frame
    void Update()
    {
        gameTime = Time.time;
    }
    public void IncrementGod()
    {
        god++;
    }

    public void IncrementMeat()
    {
        meat++;
    }
    public void IncrementCoins(int amount)
    {
        coins += amount;
    }

    public void IncrementDash()
    {
        dashes++;
    }
    public void IncrementPickUps()
    {
        pickup++;
    }
    public void IncrementWave()
    {
        wave++;
    }
}
