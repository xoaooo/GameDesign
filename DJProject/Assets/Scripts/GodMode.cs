using System.Collections;
using UnityEngine;

public class GodMode : MonoBehaviour
{
    public bool hasGodMode = false;
    public float godModeTimer = 5f;
    public float speed;
    private GameObject[] enemies;
    public bool canActivate = true;
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
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        yield return new WaitForSeconds(godModeTimer);
        hasGodMode = false;
        animator.SetBool("hasGodmode", hasGodMode);
        yield return new WaitForSeconds(5f);
        canActivate = true;
    }
}
