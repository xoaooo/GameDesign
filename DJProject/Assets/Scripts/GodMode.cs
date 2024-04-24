using System.Collections;
using UnityEngine;

public class GodMode : MonoBehaviour
{
    private bool hasGodMode = false;
    public float godModeTimer = 5f;
    public float speed;
    private GameObject player;
    private GameObject[] enemies;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        
    }
    void Update()
    {
        if (!hasGodMode)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Debug.Log("HIIIIIIIIIIIII");
                StartCoroutine(GodModeTimer());
            }
        }

    }


    IEnumerator GodModeTimer()
    {
        hasGodMode = true;
        animator.SetBool("hasGodmode", hasGodMode);
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        runAway(enemies);
        yield return new WaitForSeconds(godModeTimer);
        //runToPlayer(enemies);
        
        hasGodMode = false;
        animator.SetBool("hasGodmode", hasGodMode);
    }

    private void runAway(GameObject[] enemies)
    {
        foreach (GameObject enemy in enemies)
        {
            Debug.Log(enemies.Length);
            enemy.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, speed);
        }
    }

    private void runToPlayer(GameObject[] enemies)
    {
        foreach (GameObject enemy in enemies)
        {
            enemy.transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemy.GetComponent<Target>().speed * Time.deltaTime);
        }
    }
}
