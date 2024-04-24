using System.Collections;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public float damage;
    public float speed;
    private float godModeCooldown = -1f;
    public GameObject coin;
    private GameObject player, meat;
    public bool hasGodMode = false;
    public float godModeTimer = 5f;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        godModeCooldown--;
        
        if (Input.GetKeyDown(KeyCode.Mouse0) && godModeCooldown <= 0)
        {
            StartCoroutine(GodModeTimer());
        }


        if (!hasGodMode)
        {
            meat = GameObject.FindWithTag("Meat");
            if (meat != null)
            {
                transform.position = Vector2.MoveTowards(transform.position, meat.transform.position, speed * Time.deltaTime);
            }
            else if (player != null)
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasGodMode)
            Destroy(gameObject);
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        Instantiate(coin, transform.position, transform.rotation);
    }

    IEnumerator GodModeTimer()
    {
        hasGodMode = true;
        runAway();
        yield return new WaitForSeconds(godModeTimer);
        godModeCooldown = 10f;
        hasGodMode = false;
    }

    private void runAway()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, speed);
    }
}
