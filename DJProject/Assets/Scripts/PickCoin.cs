using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PickCoin : MonoBehaviour
{
    public static int coins;
    public TMP_Text coinAmount;
    // Start is called before the first frame update
    void Start()
    {
        coins = 0;
        coinAmount.text = coins.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            coins += 10;
            coinAmount.text = coins.ToString();
        }
    }
}
