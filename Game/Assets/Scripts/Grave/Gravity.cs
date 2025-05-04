using OkapiKit;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Gravity : MonoBehaviour
{
    // The distance between the player and the grave to make the grave fall
    [SerializeField]
    private float distanceThreshold = 75f;

    // The player's transform
    private Transform playerTransform;
    // The rigidbody of the grave object
    private Rigidbody2D grave;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        grave = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the distance between the player and the grave
        float distanceToPlayer = Vector2.Distance(playerTransform.position, transform.position);
        
        // If the player is close enough to the grave, the player can press the Fire1 to make the grave fall
        if (distanceToPlayer < distanceThreshold)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                grave.position = Vector2.MoveTowards (grave.position, new Vector2 (grave.position.x, -64), 5);
            }
            if (grave.position.y >= -64 && Input.GetButtonDown("Fire1"))
            {
                grave.position = new Vector2(grave.position.x, -80);
            }



            /*
            // If the player presses the S key, the grave falls
            if (Input.GetButtonDown("Fire1"))
            {
               grave.linearVelocity = new Vector2(0, 16); 
            }
            // If the grave is below the ground, it stops falling
            if (grave.position.y == 16)
            {
               grave.linearVelocity = new Vector2(0, 0);
            }
            */            
        }  
    }
}
