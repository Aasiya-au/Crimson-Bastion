using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [Header("Shooting Settings")]
    public ObjectPooler pooler;
    public float bulletSpeed = 3f;
    public float shootCooldown = 5f;
    public AudioClip shootSound;
    public AudioSource audioSource;

    private float shootTimer;
    private Transform player;
    private EnemyController controller;

    private void Awake()
    {
        controller = GetComponentInParent<EnemyController>(); // safer
    }

    private void OnEnable()
    {
        shootTimer = 0f;
        player ??= GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    private void Update()
    {
        if (player == null || controller == null) return;

        shootTimer += Time.deltaTime;
        float distance = Mathf.Abs(player.position.x - transform.position.x);

        if (distance < 10f && shootTimer >= shootCooldown)
        {
            Shoot();
            shootTimer = 0f;
        }
    }

    private void Shoot()
    {
        if (pooler == null) return;

        GameObject bullet = pooler.SpawnFromPool("EnemyBullet", transform.position, Quaternion.identity);
        if (bullet == null) return;

        if (audioSource && shootSound)
            audioSource.PlayOneShot(shootSound);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            float dir = -Mathf.Sign(controller.transform.localScale.x);
            rb.velocity = new Vector2(dir * bulletSpeed, 0f);
        }
    }
}
