using System;
using TMPro;
using UnityEngine;

public class Statistics : MonoBehaviour
{
    public TMP_Text Time, Gold, Waves, Pickups, Power1, Power2, Power3;

    void Start()
    {
        TimeSpan time = TimeSpan.FromSeconds(PlayerStatistics.gameTime);

        Time.text = time.ToString("hh':'mm':'ss");
        Gold.text = PlayerStatistics.coins.ToString();
        Waves.text = PlayerStatistics.wave.ToString();
        Pickups.text = PlayerStatistics.pickup.ToString();
        Power1.text = PlayerStatistics.god.ToString();
        Power2.text = PlayerStatistics.meat.ToString();
        Power3.text = PlayerStatistics.dashes.ToString();
    }
}
