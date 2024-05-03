using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Statistics : MonoBehaviour
{
    public TMP_Text Time, Gold, Waves, Enemies, Power1, Power2;
    
    void Start()
    {
        Time.text = "N/A";
        Gold.text = CoinBehaviour.coins.ToString();
        Waves.text = "N/A ";
        Enemies.text = "N/A";
        Power1.text = "N/A";
        Power2.text = "N/A";
    }
}
