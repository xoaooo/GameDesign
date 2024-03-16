using UnityEngine;
using System.Collections;

public class CharacterHealth : MonoBehaviour
{
    public float health = 100f;
    public float invulnerabilityTime = 0.5f; // Time in seconds for invulnerability after taking damage

    public Color flashColor = new Color(1f, 0f, 0f, 0.5f); // Flash color (red with 50% transparency)
    private SpriteRenderer spriteRenderer;

    private bool isInvulnerable = false;

    [SerializeField] private Knockback knockback;
    [SerializeField] private Rigidbody2D rb;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isInvulnerable && collision.gameObject.CompareTag("Enemy"))
        {
            Target enemy = collision.gameObject.GetComponent<Target>();
            TakeDamage(enemy);
            knockback.PlayFeedback(collision.gameObject);
            StartCoroutine(InvulnerabilityTimer());
        }
    }

    void TakeDamage(Target enemy)
    {
        health -= enemy.damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator InvulnerabilityTimer()
    {
        isInvulnerable = true;
        spriteRenderer.color = flashColor;
        yield return new WaitForSeconds(invulnerabilityTime);
        spriteRenderer.color = Color.white;
        isInvulnerable = false;
    }
}