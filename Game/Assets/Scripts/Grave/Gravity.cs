using OkapiKit;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Gravity : MonoBehaviour
{
    // The player's transform
    private Transform playerTransform;

    // The distance between the player and the grave to make the grave fall
    public float distanceThreshold = 150f;

    // The rigidbody of the grave object
    private Rigidbody2D grave;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Find the player object
        GameObject player = GameObject.FindWithTag("Player");

        // If the player object is not null, get the player's transform
        if (player != null)
        {
            playerTransform = player.transform;
        }

        // Get the rigidbody of the grave
        grave = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the distance between the player and the grave
        float distanceToPlayer = Vector2.Distance(playerTransform.position, transform.position);
        
        // If the player is close enough to the grave, the player can press the S key to make the grave fall
        if (distanceToPlayer < distanceThreshold)
        {
            // If the player presses the S key, the grave falls
            if (Input.GetKeyDown(KeyCode.S))
            {
               grave.linearVelocity = new Vector2(0, -32); 
            }
            // If the grave is below the ground, it stops falling
            if (grave.position.y < -352)
            {
               grave.linearVelocity = new Vector2(0, 0);
            }
        }   
    }
}
