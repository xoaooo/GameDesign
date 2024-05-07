using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public static TMP_Text coinAmount;

    public static GameObject meat;
    public static GameObject star;
    public static GameObject dash;
    // Start is called before the first frame update
    public static int amount;
    void Start()
    {
        GameObject textObject = GameObject.FindWithTag("CoinAmount");
        coinAmount = textObject.GetComponent<TMP_Text>();
        amount = 0;
        coinAmount.text = amount.ToString();
        meat = GameObject.FindGameObjectWithTag("IconMeat");
        dash = GameObject.FindGameObjectWithTag("IconDash");
        star = GameObject.FindGameObjectWithTag("IconStar");
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
    public static void ActivateStarCooldown()
    {
        star.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.35f);
    }
    public static void EndStarCooldown()
    {
        star.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }
    public static void ActivateMeatCooldown()
    {
        meat.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.35f);
    }
    public static void EndMeatCooldown()
    {
        meat.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }
    public static void ActivateDashCooldown()
    {
        dash.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.35f);
    }
    public static void EndDashCooldown()
    {
        dash.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }
}
