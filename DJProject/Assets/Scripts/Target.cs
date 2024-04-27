using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public float damage;
    public float speed;
    public GameObject coin;
    private GameObject player, meat;
    public bool hasGodMode;
    public TMP_Text coinAmount;
    private bool canActivate;

    void Start()
    {
        GameObject textObject = GameObject.FindWithTag("CoinAmount");
        coinAmount = textObject.GetComponent<TMP_Text>();
        player = GameObject.FindWithTag("Player");
        coinAmount.text = PickCoin.coins.ToString();
    }

    void Update()
    {
        //Debug.Log(canActivate);
        canActivate = player.GetComponent<GodMode>().canActivate;
        hasGodMode = player.GetComponent<GodMode>().hasGodMode;

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
                transform.position = Vector2.MoveTowards(transform.position, meat.transform.position, speed * Time.deltaTime);
            }
            else if (player != null)
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasGodMode && collision.gameObject.CompareTag("Player"))
        {
            Die();
            PickCoin.coins += 10;
            coinAmount.text = PickCoin.coins.ToString();
        }
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
