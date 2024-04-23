using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Statistics : MonoBehaviour
{
    public TMP_Text Time;
    public TMP_Text Gold;
    public TMP_Text Waves;
    public TMP_Text Enemies;
    public TMP_Text Power1;
    public TMP_Text Power2;

    // Start is called before the first frame update
    void Start()
    {
        Time.text = "N/A";
        Gold.text = PickCoin.coins.ToString();
        Waves.text = "N/A ";
        Enemies.text = "N/A";
        Power1.text = "N/A";
        Power2.text = "N/A";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
