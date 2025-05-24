using System.Runtime.CompilerServices;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector2 velocity;
    [SerializeField] private string horizontalAxisName = "Horizontal";
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundCheckLayers;
    [SerializeField, Range(0.1f, 5.0f)] private float groundCheckRadius = 2.0f;
    [SerializeField, Header("Jump Settings")] private float jumpMaxDuration = 0.1f;
    [SerializeField] private float jumpGravityScale = 1.0f;
    [SerializeField, Header("Player Visuals")] private Animator animator;
    [SerializeField] private Collider2D groundCollider;
    [SerializeField] private Collider2D airCollider;
    [SerializeField] private ParticleSystem groundCollisionParticles;

    private Rigidbody2D rigidBodyPlayer;
    private SpriteRenderer playerRenderer;
    private Quaternion initialRotation;
    private bool isGround;
    private bool groundCollision = false;
    private float jumpTimer;
    private float originalGravity;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBodyPlayer = GetComponent<Rigidbody2D>();
        playerRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        groundCollisionParticles = GetComponentInChildren<ParticleSystem>();
        initialRotation = transform.rotation;
        originalGravity = rigidBodyPlayer.gravityScale;
    }
    // Update is called once per frame
    void Update()
    {
        Grounded();
        groundCollider.enabled = isGround;
        airCollider.enabled = !isGround;
        VisualsUpdate();
        Jump();

        if (isGround && groundCollision)
        {
            groundCollisionParticles.Play();
            groundCollision = false;
        }
        else if (!isGround)
        {
            groundCollision = true;
        }
    }

    // Detect if the player is on the ground
    void Grounded()
    {
        Collider2D collider = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundCheckLayers);

        // Check if the player is on the ground by checking for collisions with the ground layer+
        if (collider != null)
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }
    }

    // Update the player visuals based on the current state and the player's movement
    void VisualsUpdate()
    {
        float playerMovHorizontal = Input.GetAxis(horizontalAxisName);

        Vector2 currentVelocity = rigidBodyPlayer.linearVelocity;
        currentVelocity.x = playerMovHorizontal * velocity.x;

        // Move the player horizontally
        if ((playerMovHorizontal < 0) && (transform.right.x > 0))
        {
            transform.rotation = initialRotation * Quaternion.Euler(0.0f, 180.0f, 0.0f);
        }
        else if ((playerMovHorizontal > 0) && (transform.right.x < 0))
        {
            transform.rotation = initialRotation;
        }

        // Set the animator parameters
        animator.SetFloat("AbsVelocityX", Mathf.Abs(currentVelocity.x));
        animator.SetFloat("VelocityY", currentVelocity.y);
        animator.SetBool("IsGrounded", isGround);
    }

    // Jumping logic
    void Jump()
    {
        float playerMovHorizontal = Input.GetAxis(horizontalAxisName);
        Vector2 currentVelocity = rigidBodyPlayer.linearVelocity;
        currentVelocity.x = playerMovHorizontal * velocity.x;

        // Check if the player is on the ground and if the jump button is pressed
        if (Input.GetButtonDown("Jump"))
        {
            if (isGround)
            {
                currentVelocity.y = velocity.y;
                jumpTimer = 0.0f;
                rigidBodyPlayer.gravityScale = jumpGravityScale;
            }
        }

        else if (jumpTimer < jumpMaxDuration)
        {
            jumpTimer += Time.deltaTime;

            // If the jump button is still pressed, apply jump gravity
            if (Input.GetButton("Jump"))
            {
                rigidBodyPlayer.gravityScale = Mathf.Lerp(jumpGravityScale, originalGravity, jumpTimer / jumpMaxDuration);
            }

            // If the jump button is released, reset the jump timer and gravity scale
            else
            {
                jumpTimer = jumpMaxDuration;
                rigidBodyPlayer.gravityScale = originalGravity;
            }
        }

        // If the player is on the ground, reset the jump timer and gravity scale
        else
        {
            rigidBodyPlayer.gravityScale = originalGravity;
        }

        rigidBodyPlayer.linearVelocity = currentVelocity;
    }

    // Draw gizmos in the editor to visualize the check points
    void OnDrawGizmos()
    {
        if (groundCheck == null)
        {
            return;
        }

        if (isGround)
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.yellow;
        }

        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
