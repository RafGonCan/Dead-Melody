using UnityEngine;

public class Open : MonoBehaviour
{
    // The animator of the door
    private Animator _animator;
    // The player's transform
    private Transform playerTransform;
    // The collider of the door
    private BoxCollider2D DoorCollider;
    // The distance between the player and the door to open the door
    [SerializeField]
    private float distanceThreshold = 150f;
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
        // Get the animator of the door
        _animator = GetComponent<Animator>();
        // Get the collider of the door
        DoorCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the distance between the player and the door
        float distanceToPlayer = Vector2.Distance(playerTransform.position, transform.position);
        // If the player is close enough to the door, the player can press the S key to open the door
        if (distanceToPlayer < distanceThreshold)
        {
            // If the player presses the S key, the door opens
            // The door collider is disabled to allow the player to pass through the door
            if (Input.GetKey(KeyCode.S))
            {
                DoorCollider.enabled = false;
                _animator.SetBool("Open", true);
            }
        }
    }
}
