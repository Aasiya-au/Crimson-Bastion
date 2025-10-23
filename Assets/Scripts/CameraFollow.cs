using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    [Header("Camera Limits")]
    public bool useLimits = true;
    public float minX;
    public float maxX;

    [Header("Vertical Follow Settings")]
    public float verticalThreshold = 2f;  // how high player must go before camera moves up
    public float verticalLerpSpeed = 0.05f; // how smoothly camera moves vertically

    private float targetY; // camera's desired Y position

    void Start()
    {
        if (player != null)
            targetY = transform.position.y;
    }

    void LateUpdate()
    {
        if (player == null) return;

        // --- X follow (always) ---
        Vector3 desiredPosition = new Vector3(player.position.x + offset.x, targetY, transform.position.z);

        // --- Check Y threshold ---
        float playerY = player.position.y + offset.y;
        if (Mathf.Abs(playerY - targetY) > verticalThreshold)
        {
            targetY = Mathf.Lerp(targetY, playerY, verticalLerpSpeed);
        }

        // --- Smooth movement ---
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // --- Clamp X limits if enabled ---
        if (useLimits)
            smoothedPosition.x = Mathf.Clamp(smoothedPosition.x, minX, maxX);

        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
    }
}
