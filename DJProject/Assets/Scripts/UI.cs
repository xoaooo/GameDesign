using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public static TMP_Text coinAmount;
    public static TMP_Text godUses;
    public static TMP_Text meatUses;
    public static TMP_Text waveNumberUI;

    public static GameObject meat;
    public static GameObject star;
    public static GameObject dash;

    public static GameObject wavePanel;
    public static GameObject waveButton;

    public static TMP_Text waveTimer;

    private static Animator animator;

    [SerializeField] AudioClip musicBackground;

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
        animator = GameObject.FindWithTag("Player").GetComponent<Animator>();
        waveNumberUI.text = "1";

        SoundFXManager.instance.PlayMusic(musicBackground, transform, 0.15f);
    }

    void Awake()
    {
        GameObject textObject = GameObject.FindWithTag("CoinAmount");
        coinAmount = textObject.GetComponent<TMP_Text>();
        textObject = GameObject.FindWithTag("UsesMeat");
        meatUses = textObject.GetComponent<TMP_Text>();
        textObject = GameObject.FindWithTag("UsesGod");
        godUses = textObject.GetComponent<TMP_Text>();
        wavePanel = GameObject.Find("WaveWinner");
        textObject = GameObject.FindWithTag("WaveNumber");
        waveNumberUI = textObject.GetComponent<TMP_Text>();
        textObject = GameObject.FindWithTag("WaveTimer");
        waveTimer = textObject.GetComponent<TMP_Text>();
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
        Time.timeScale = 0;
    }

    public static void disableWaveCanvas()
    {
        wavePanel.SetActive(false);
        var waveSpawner = GameObject.FindWithTag("WaveSpawner");
        waveSpawner.GetComponent<SpawnEnemies>().waveStatus = 0;
        var waveNumber = waveSpawner.GetComponent<SpawnEnemies>().NextWave();
        Debug.Log(waveNumber);
        waveNumberUI.text = "" + waveNumber;
        if (waveNumber == 5)
            SceneManager.LoadScene("Ending");
        waveSpawner.GetComponent<SpawnEnemies>().waveTime = 30f + waveNumber * 5;
        waveSpawner.GetComponent<SpawnEnemies>().respawnTime = 10f - waveNumber;
        waveSpawner.GetComponent<SpawnEnemies>().countdown = 10f - waveNumber;
        Time.timeScale = 1;
        animator.SetBool("hasGodmode", false);

    }
    public static void updateTimer(float time)
    {
        string formattedNumber = time.ToString("F2");
        float roundedNumber = float.Parse(formattedNumber);
        waveTimer.text = roundedNumber.ToString();
    }
}
