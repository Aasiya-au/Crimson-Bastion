using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    public bool facingRight = true;
    private Animator anim;

    public float jumpForce = 10f;
    private bool isGrounded = false;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float checkRadius = 0.2f;
    private bool shouldJump = false;
    public float deathDelay = 0.2f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");

        // walking animation
        bool isMoving = Mathf.Abs(moveInput.x) > 0;
        anim.SetBool("isWalking", isMoving);

        // flip
        if (moveInput.x > 0 && !facingRight)
            Flip();
        else if (moveInput.x < 0 && facingRight)
            Flip();

        // jump
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            shouldJump = true;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Shoot");
        }
    }

    void FixedUpdate()
    {
        // check if grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        // horizontal movement using velocity
        rb.velocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);

        // jump physics logic
        if (shouldJump)
        {
            // Apply the jump force
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            shouldJump = false; // Reset flag after applying
            // Note: isGrounded will be false on the next FixedUpdate check
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }
    public void Die()
    {
        anim.SetTrigger("Die");          // play death animation
        StartCoroutine(DeathSequence());
    }

    IEnumerator DeathSequence()
    {
        yield return new WaitForSeconds(deathDelay);
        SceneManager.LoadScene("LoseScene");
    }
}
