using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public float damage;
    public float speed;
    private GameObject player, meat;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        meat = GameObject.FindWithTag("Meat");
        if (meat != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, meat.transform.position, speed * Time.deltaTime);
        }
        else if (player != null)
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
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
}
