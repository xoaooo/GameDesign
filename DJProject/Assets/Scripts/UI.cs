using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public static TMP_Text coinAmount;
    // Start is called before the first frame update
    public static int amount;
    void Start()
    {
        GameObject textObject = GameObject.FindWithTag("CoinAmount");
        coinAmount = textObject.GetComponent<TMP_Text>();
        amount = 0;
        coinAmount.text = amount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public static void AddCoin()
    {
        amount += 10;
        coinAmount.text = amount.ToString();
    }
}
