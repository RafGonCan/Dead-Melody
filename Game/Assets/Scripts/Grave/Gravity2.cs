using OkapiKit;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Gravity : MonoBehaviour
{
    // The distance between the player and the crate to make the crate fall
    [SerializeField]
    private float distanceThreshold = 75f;

    // The player's transform
    private Transform playerTransform;
    // The rigidbody of the crate object
    private Rigidbody2D crate;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        crate = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the distance between the player and the crate
        float distanceToPlayer = Vector2.Distance(playerTransform.position, transform.position);
        
        // If the player is close enough to the crate, the player can press the Fire1 to make the crate fall
        if (distanceToPlayer < distanceThreshold)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                crate.position = Vector2.MoveTowards (crate.position, new Vector2 (crate.position.x, -32), 5);
            }
            if (crate.position.y <= -32 && Input.GetButtonDown("Fire1"))
            {
                crate.position = new Vector2(crate.position.x, -16);
            }



            /*
            // If the player presses the S key, the crate falls
            if (Input.GetButtonDown("Fire1"))
            {
               crate.linearVelocity = new Vector2(0, 16); 
            }
            // If the crate is below the ground, it stops falling
            if (crate.position.y == 16)
            {
               crate.linearVelocity = new Vector2(0, 0);
            }
            */            
        }  
    }
}
