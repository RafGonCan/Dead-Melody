using OkapiKit;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Gravity : MonoBehaviour
{
    private Transform playerTransform;

    public float distanceThreshold = 256f;

    private Rigidbody2D grave;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        grave = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector2.Distance(playerTransform.position, transform.position);
        
        if (distanceToPlayer < distanceThreshold)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
               grave.linearVelocity = new Vector2(0, -32); 
            }
            if (grave.position.y < -352)
            {
                grave.linearVelocity = new Vector2(0, 0);
            }
        }   
    }
}
