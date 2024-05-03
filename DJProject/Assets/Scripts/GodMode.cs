using System.Collections;
using UnityEngine;

public class GodMode : MonoBehaviour
{
    public bool hasGodMode = false, canActivate = true;
    public float speed, godModeTimer = 5f, godModeCooldown = 5f;
    private Animator animator;

    AudioManager audioManager;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }

    void Update()
    {
        if (!hasGodMode && canActivate)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                audioManager.PlaySFX(audioManager.godMode);
                StartCoroutine(GodModeTimer());
            }
        }
        else if (!hasGodMode && !canActivate && Input.GetKeyDown(KeyCode.Mouse0)) {

            audioManager.PlaySFX(audioManager.nope);
        }

    }



    IEnumerator GodModeTimer()
    {
        canActivate = false;
        
        hasGodMode = true;
        animator.SetBool("hasGodmode", hasGodMode);
        yield return new WaitForSeconds(godModeTimer);
        animator.SetBool("hasGodmode", hasGodMode);
        hasGodMode = false;
        
        yield return new WaitForSeconds(godModeCooldown);
        
        canActivate = true;
    }
}
