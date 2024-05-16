using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CharacterHealth : MonoBehaviour
{
    //[SerializeField] AudioSource audioSource, musicSource;
    //[SerializeField] AudioClip hitSound, deathSound;

    public float health = 100f;
    public float invulnerabilityTime = 0.5f; // Time in seconds for invulnerability after taking damage

    public Image healthBar;

    public Color flashColor = new(1f, 0f, 0f, 0.5f); // Flash color (red with 50% transparency)
    private SpriteRenderer spriteRenderer;

    private bool isInvulnerable = false;

    [SerializeField] private Knockback knockback;
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private AudioClip[] damage;
    [SerializeField] private AudioClip death;


    //AudioManager audioManager;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isInvulnerable)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Target enemy = collision.gameObject.GetComponent<Target>();
  
                if (!enemy.hasGodMode)
                {
                    enemy.GetComponent<Rigidbody2D>().freezeRotation = true;
                    
                    TakeDamage(enemy);

                    //audioManager.PlaySFX(audioManager.damage);
                    SoundFXManager.instance.PlayRandomSFXClip(damage, transform, 0.2f);
                    knockback.PlayFeedback(collision.gameObject);
                    
                    StartCoroutine(InvulnerabilityTimer());
                }
            }
            else if (collision.gameObject.CompareTag("HitObstacle"))
            {
                health -= 10f;
                healthBar.fillAmount = health / 100f;

                //audioManager.PlaySFX(audioManager.damage);
                SoundFXManager.instance.PlayRandomSFXClip(damage, transform, 0.2f);
                knockback.PlayFeedback(collision.gameObject);
                
                StartCoroutine(InvulnerabilityTimer());

                if (health <= 0)
                {
                    GameOver();
                }
            }
        }
    }

    void TakeDamage(Target enemy)
    {
  
        health -= enemy.damage;
        healthBar.fillAmount = health / 100f;

        if (health <= 0)
        {
           GameOver();
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

    public void GameOver()
    {
        Movement movement = GetComponent<Movement>();
        if (movement != null)
        {
            movement.CanMove();
        }
        //audioManager.PlayMusic(audioManager.death);
        
        Destroy(gameObject);
        
        SceneManager.LoadScene("Game Over", LoadSceneMode.Single);
    }


    public void RestoreHealth(float amount)
    {
        health = Mathf.Clamp(health + amount, 0f, 100f);
        healthBar.fillAmount = health / 100f;
    }
}