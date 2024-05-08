using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public static TMP_Text coinAmount;
    public static TMP_Text godUses;
    public static TMP_Text meatUses;

    public static GameObject meat;
    public static GameObject star;
    public static GameObject dash;

    public static GameObject wavePanel;
    public static GameObject waveButton;

    // Start is called before the first frame update
    public static int amount;
    void Start()
    {
        amount = 0;
        coinAmount.text = amount.ToString();
        meat = GameObject.FindGameObjectWithTag("IconMeat");
        dash = GameObject.FindGameObjectWithTag("IconDash");
        star = GameObject.FindGameObjectWithTag("IconStar");
        wavePanel.SetActive(false);
    }

    void Awake()
    {
        GameObject textObject = GameObject.FindWithTag("CoinAmount");
        coinAmount = textObject.GetComponent<TMP_Text>();
        textObject = GameObject.FindWithTag("UsesMeat");
        meatUses = textObject.GetComponent<TMP_Text>();
        textObject = GameObject.FindWithTag("UsesGod");
        godUses = textObject.GetComponent<TMP_Text>();
        wavePanel = GameObject.Find("CanvasWave");
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

    public static void updateMeat(int amount)
    {
        meatUses.text = amount.ToString();
    }
    public static void updateGod(int amount)
    {
        godUses.text = amount.ToString();
    }

    public static void enableWaveCanvas()
    {
        wavePanel.SetActive(true);
    }
}