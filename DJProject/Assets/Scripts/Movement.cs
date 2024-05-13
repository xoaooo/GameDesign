using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;

    private bool canDash = true, isDashing;
    private bool move = true;
    private float dashingPower = 24f;
    private float dashTime = 0.2f;
    private float dashingCooldown = 3f;
    [SerializeField] private Rigidbody2D rb;
    PlayerStatistics statistics;

    public Color flashColor;
    private SpriteRenderer spriteRenderer;

    private Animator animator;

    AudioManager audioManager;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        statistics = FindObjectOfType<PlayerStatistics>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePostition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 inputVector = new Vector2(0, 0);
        if (move)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
            {
                statistics.IncrementDash();
                StartCoroutine(Dashing());
            }

            if (!isDashing)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    inputVector.y += 1;
                }
                if (Input.GetKey(KeyCode.S))
                {
                    inputVector.y -= 1;
                }
                if (Input.GetKey(KeyCode.A))
                {
                    transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f); // Flip the player to face left
                    inputVector.x -= 1;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    transform.localScale = new Vector3(0.5f, 0.5f, 1);
                    inputVector.x += 1;
                }



                inputVector = inputVector.normalized;

                animator.SetBool("isWalking", inputVector != Vector2.zero);

                transform.position += (Vector3)inputVector * moveSpeed * Time.deltaTime;
            }
        }

    }

    private IEnumerator Dashing()
    {
        UI.ActivateDashCooldown();
        canDash = false;
        isDashing = true;

        Vector2 dashDirection = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            dashDirection += Vector2.up;
        }

        if (Input.GetKey(KeyCode.S))
        {
            dashDirection += Vector2.down;
        }

        if (Input.GetKey(KeyCode.A))
        {
            dashDirection += Vector2.left;
        }

        if (Input.GetKey(KeyCode.D))
        {
            dashDirection += Vector2.right;
        }

        // Normalize the direction to ensure consistent speed in diagonal dashing
        if (dashDirection != Vector2.zero)
        {
            dashDirection.Normalize();
        }
        else
        {
            // If no directional keys are pressed, default to horizontal dash
            dashDirection = new Vector2(transform.localScale.x, 0);
        }

        rb.velocity = dashDirection * dashingPower;

        audioManager.PlaySFX(audioManager.dash);

        spriteRenderer.color = flashColor;
        yield return new WaitForSeconds(dashTime);
        rb.velocity = Vector2.zero;
        spriteRenderer.color = Color.white;

        isDashing = false;

        yield return new WaitForSeconds(dashingCooldown);
        UI.EndDashCooldown();
        canDash = true;
    }


    public void CanMove()
    {
        move = !move;
    }
}
