using System.Collections;
using TMPro;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public float damage;
    public float speed;
    private GameObject player, meat;
    public bool hasGodMode;
    private bool canActivate;
    
    //private AudioManager audioManager;
    
    private bool isEating;
    private Animator animator;
    PlayerStatistics statistics;

    [SerializeField] AudioClip eat;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        statistics = FindObjectOfType<PlayerStatistics>();
    }

    void Start()
    {
        //audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        player = GameObject.FindWithTag("Player");
        Physics2D.IgnoreLayerCollision(6, 7);
    }

    void Update()
    {
        if (player != null)
        {
            canActivate = player.GetComponent<GodMode>().canActivate;
            hasGodMode = player.GetComponent<GodMode>().hasGodMode;
        }

        if (canActivate && Input.GetKeyDown(KeyCode.Mouse0))
        {
            hasGodMode = true;
            StartCoroutine(GodModeTimer());
            hasGodMode = false;
        }


        if (!hasGodMode)
        {
            meat = GameObject.FindWithTag("Meat");
            if (meat != null)
            {
                Debug.Log(speed);
                transform.position = Vector2.MoveTowards(transform.position, meat.transform.position, speed * Time.deltaTime);
                isEating = Vector2.Distance(transform.position, meat.transform.position) <= 2.5;
                //SoundFXManager.instance.PlaySFXClip(eat, transform, 0.1f);
            }
            else if (player != null)
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            else
            {
                isEating = false;
                
            }

        }

        animator.SetBool("isEating", isEating);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasGodMode && collision.gameObject.CompareTag("Player"))
        {
            UI.AddCoin();
            statistics.IncrementCoins(10);
            Destroy(gameObject);
            //audioManager.PlaySFX(audioManager.coin);
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator GodModeTimer()
    {
        runAway();
        yield return new WaitForSeconds(5f);
    }

    private void runAway()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, speed);
    }
}
