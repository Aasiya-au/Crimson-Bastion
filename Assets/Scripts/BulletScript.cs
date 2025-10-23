using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour
{
    public float deathDelay = 0.2f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            // Disable target and bullet
            collision.gameObject.SetActive(false);
            gameObject.SetActive(false);
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
