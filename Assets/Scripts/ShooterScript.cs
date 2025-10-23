using UnityEngine;

public class ShooterScript : MonoBehaviour
{
    public ObjectPooler pooler;      // Drag your ObjectPooler here
    public float bulletSpeed;
    public PlayerMovement player;
    public AudioClip shootSound;
    public AudioSource audioSource;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = pooler.SpawnFromPool("Bullet", transform.position, Quaternion.identity);
            audioSource.PlayOneShot(shootSound);

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (player.transform.localScale.x > 0)
                rb.velocity = Vector2.right * bulletSpeed;
            else
                rb.velocity = Vector2.left * bulletSpeed;
        }
    }
}
