using UnityEngine;

public class SonicCameraFollow : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private Transform target;

    [Header("Look-Ahead")]
    [SerializeField] private float lookAheadDistance = 3f;
    [SerializeField] private float lookSmoothTime = 0.1f;

    [Header("Vertical Follow")]
    [SerializeField] private float verticalSmoothTime = 0.2f;

    [Header("Camera Bounds")]
    [SerializeField] private Vector2 minCameraPos;
    [SerializeField] private Vector2 maxCameraPos;

    private Vector3 currentVelocity;
    private float currentLookAhead;
    private float targetLookAhead;
    private float currentVelocityY;

    private Rigidbody2D targetRb;

    void Start()
    {
        targetRb = target.GetComponent<Rigidbody2D>();
    }

    void LateUpdate()
    {
        if (!target) return;

        // Calculate look-ahead based on horizontal velocity
        if (Mathf.Abs(targetRb.linearVelocity.x) > 0.1f)
        {
            targetLookAhead = lookAheadDistance * Mathf.Sign(targetRb.linearVelocity.x);
        }
        else
        {
            targetLookAhead = 0f;
        }

        // Smooth look-ahead transition
        currentLookAhead = Mathf.SmoothDamp(currentLookAhead, targetLookAhead, ref currentVelocity.x, lookSmoothTime);

        // Smooth vertical follow
        float desiredY = target.position.y;
        float smoothedY = Mathf.SmoothDamp(transform.position.y, desiredY, ref currentVelocityY, verticalSmoothTime);

        // Combine position
        Vector3 newPos = new Vector3(target.position.x + currentLookAhead, smoothedY, transform.position.z);

        // Clamp camera within bounds
        newPos.x = Mathf.Clamp(newPos.x, minCameraPos.x, maxCameraPos.x);
        newPos.y = Mathf.Clamp(newPos.y, minCameraPos.y, maxCameraPos.y);

        // Apply position
        transform.position = newPos;
    }
}
