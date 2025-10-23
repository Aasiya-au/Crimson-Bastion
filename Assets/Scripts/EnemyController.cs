using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 2f;
    private Transform player;
    private Rigidbody2D rb;
    private Animator anim;
    private bool facingRight = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        // Cache player only once when enabled (faster than finding every frame)
        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
                player = playerObj.transform;
        }
    }

    private void FixedUpdate()
    {
        if (player == null) return;

        Vector2 direction = (player.position - transform.position).normalized;

        rb.velocity = new Vector2(direction.x * moveSpeed, rb.velocity.y);

        // Flip only when needed (avoids unnecessary scale changes)
        if ((direction.x > 0 && !facingRight) || (direction.x < 0 && facingRight))
            Flip();

        // Example: shoot when close to player
        if (Mathf.Abs(player.position.x - transform.position.x) < 10f)
        {
            anim.SetTrigger("Shoot");
        }
    }

    public void Die()
    {
        anim.SetTrigger("Die");          // play death animation
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
