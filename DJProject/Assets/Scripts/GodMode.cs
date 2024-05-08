using System.Collections;
using UnityEngine;

public class GodMode : MonoBehaviour
{
    public bool hasGodMode = false, canActivate = true;
    public float speed, godModeTimer = 5f, godModeCooldown = 5f;
    public int godModeCharges;
    PlayerStatistics statistics;

    private Animator animator;

    AudioManager audioManager;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        statistics = FindObjectOfType<PlayerStatistics>();

    }

    void Update()
    {
        if (!hasGodMode && canActivate)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                statistics.abilityCount++;
                UI.ActivateStarCooldown();
                audioManager.PlaySFX(audioManager.godMode);
                StartCoroutine(GodModeTimer());
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
    }
}
