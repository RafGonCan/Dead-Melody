using UnityEngine;


public class CameraFollow2D : MonoBehaviour
{
    [SerializeField] private Transform target; 
    private float smoothSpeed = 0.125f;

    [SerializeField] private Vector2 offset = new Vector2(2f, 1f); 
    [SerializeField] private Vector2 followSpeed = new Vector2(5f, 3f); 
    [SerializeField] private Vector2 deadZone = new Vector2(0.5f, 0.5f); 

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = transform.position;

        Vector3 delta = target.position - transform.position;

        // Horizontal follow with look-ahead
        if (Mathf.Abs(delta.x) > deadZone.x)
            desiredPosition.x = Mathf.Lerp(transform.position.x, target.position.x + Mathf.Sign(delta.x) * offset.x, followSpeed.x * Time.deltaTime);

        // Vertical follow
        if (Mathf.Abs(delta.y) > deadZone.y)
            desiredPosition.y = Mathf.Lerp(transform.position.y, target.position.y + Mathf.Sign(delta.y) * offset.y, followSpeed.y * Time.deltaTime);

        desiredPosition.z = transform.position.z;

        transform.position = desiredPosition;
    }
}
