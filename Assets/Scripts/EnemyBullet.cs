using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerMovement>().Die(); // Call Player's death logic
            gameObject.SetActive(false);           // return bullet to pool
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            gameObject.SetActive(false);
        }
    }

    void OnEnable()
    {
        Invoke(nameof(Deactivate), 5f); // auto deactivate if missed
    }

    void OnDisable()
    {
        CancelInvoke(); // avoid leftover invoke calls
    }

    void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
