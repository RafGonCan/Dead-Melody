using UnityEngine;

public class CameraFollow : MonoBehaviour
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

        if (Mathf.Abs(targetRb.linearVelocity.x) > 0.1f)
        {
            targetLookAhead = lookAheadDistance * Mathf.Sign(targetRb.linearVelocity.x);
        }
        else
        {
            targetLookAhead = 0f;
        }

        currentLookAhead = Mathf.SmoothDamp(currentLookAhead, targetLookAhead, ref currentVelocity.x, lookSmoothTime);

        float desiredY = target.position.y;
        float smoothedY = Mathf.SmoothDamp(transform.position.y, desiredY, ref currentVelocityY, verticalSmoothTime);

        Vector3 newPos = new Vector3(target.position.x + currentLookAhead, smoothedY, transform.position.z);

        float vertExtent = Camera.main.orthographicSize;
        float horzExtent = vertExtent * Camera.main.aspect;

        float minX = minCameraPos.x + horzExtent;
        float maxX = maxCameraPos.x - horzExtent;
        float minY = minCameraPos.y + vertExtent;
        float maxY = maxCameraPos.y - vertExtent;

        newPos.x = Mathf.Clamp(newPos.x, minX, maxX);
        newPos.y = Mathf.Clamp(newPos.y, minY, maxY);

        transform.position = newPos;
    }
}
