using UnityEngine;
using UnityEngine.Rendering;

public class PlayerFollow : MonoBehaviour
{
    private Transform playerTransform;

    private Rigidbody2D rb;

    private Vector2 EnemyPosition;

    public float distanceThreshold = 5f;

    public float velocity = 5f;

    public float buffer = 5f;

    void Start()
    {
        GetComponent<PlayerPosition>();

        rb = GetComponent<Rigidbody2D>();

        GameObject player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            playerTransform = player.transform;
        }
    }


    void Update()
    {
        EnemyPosition = gameObject.transform.position;

        float distanceToPlayer = Vector2.Distance(playerTransform.position, transform.position);

        if (distanceToPlayer < distanceThreshold)
        {
            Vector3 diff = (playerTransform.position - transform.position).normalized;
    
            transform.position += diff * velocity * Time.deltaTime;

            rb.linearVelocity = diff * velocity;

            if (distanceToPlayer < 128f)
            {
                rb.linearVelocityg -= new Vector2(buffer, buffer);
            }

        }

        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }
}
