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

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!hasGodMode && canActivate)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                StartCoroutine(GodModeTimer());
            }
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
