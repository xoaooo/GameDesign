using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CharacterHealth : MonoBehaviour
{
    [SerializeField] AudioSource audioSource, musicSource;
    [SerializeField] AudioClip hitSound, deathSound;

    public float health = 100f;
    public float invulnerabilityTime = 0.5f; // Time in seconds for invulnerability after taking damage

    public Image healthBar;

    public Color flashColor = new(1f, 0f, 0f, 0.5f); // Flash color (red with 50% transparency)
    private SpriteRenderer spriteRenderer;

    private bool isInvulnerable = false;

    [SerializeField] private Knockback knockback;
    [SerializeField] private Rigidbody2D rb;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource.clip = hitSound;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isInvulnerable)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {

                Target enemy = collision.gameObject.GetComponent<Target>();
                enemy.GetComponent<Rigidbody2D>().freezeRotation = true;
                TakeDamage(enemy);
                audioSource.Play();
                knockback.PlayFeedback(collision.gameObject);
                StartCoroutine(InvulnerabilityTimer());
            }
            else if (collision.gameObject.CompareTag("HitObstacle"))
            {
                health -= 10f;
                healthBar.fillAmount = health / 100f;
                audioSource.Play();
                knockback.PlayFeedback(collision.gameObject);
                StartCoroutine(InvulnerabilityTimer());
            }
        }
    }

    void TakeDamage(Target enemy)
    {
        health -= enemy.damage;
        healthBar.fillAmount = health / 100f;

        if (health <= 0)
        {
            audioSource.clip = deathSound;
            musicSource.Stop();
            Destroy(gameObject);
            SceneManager.LoadScene("Game Over", LoadSceneMode.Single);
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