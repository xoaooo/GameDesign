using System.Collections;
using UnityEngine;

public class GodMode : MonoBehaviour
{
    public bool hasGodMode = false, canActivate = true;
    public float speed, godModeTimer = 5f, godModeCooldown = 5f;
    public int godModeCharges;
    PlayerStatistics statistics;
    private GameObject waveSpawner;

    private Animator animator;

    AudioManager audioManager;

    private void Start()
    {
        UI.updateGod(godModeCharges);
    }
    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        statistics = FindObjectOfType<PlayerStatistics>();
        waveSpawner = GameObject.FindWithTag("WaveSpawner");
    }

    void Update()
    {
        if (!hasGodMode && canActivate)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && waveSpawner.GetComponent<SpawnEnemies>().waveStatus != 2)
            {
                if (godModeCharges > 0)
                {
                    statistics.abilityCount++;
                    godModeCharges--;
                    UI.updateGod(godModeCharges);
                    UI.ActivateStarCooldown();
                    audioManager.PlaySFX(audioManager.godMode);
                    StartCoroutine(GodModeTimer());
                }
            }
        }
        else if (!hasGodMode && !canActivate && Input.GetKeyDown(KeyCode.Mouse0))
        {
            audioManager.PlaySFX(audioManager.nope);
        }

    }



    IEnumerator GodModeTimer()
    {
        canActivate = false;

        hasGodMode = true;
        animator.SetBool("hasGodmode", hasGodMode);
        yield return new WaitForSeconds(godModeTimer);
        hasGodMode = false;
        animator.SetBool("hasGodmode", hasGodMode);

        yield return new WaitForSeconds(godModeCooldown);

        canActivate = true;
        UI.EndStarCooldown();
    }

    public void AddGodModeCharge()
    {
        godModeCharges++;
        UI.updateGod(godModeCharges);
    }
}
