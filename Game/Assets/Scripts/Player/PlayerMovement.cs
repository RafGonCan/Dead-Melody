using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector2 velocity;

    [SerializeField] private string horizontalInputName = "Horizontal";

    [SerializeField] private string verticalInputName = "Vertical";

    [SerializeField] private float gravity = 0;

    private Rigidbody2D rb;
    
    private Animator _animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame  
    void Update()
    {
        float MovHorizontal = Input.GetAxis(horizontalInputName);

        float VerticalMov = Input.GetAxis(verticalInputName);
        if (VerticalMov > 0)
        {
            rb.gravityScale = 0;
            rb.linearVelocity = Vector2.up * velocity.y;
        }
        else if (VerticalMov < 0)
        {
            rb.gravityScale = 0;
            rb.linearVelocity = Vector2.down * velocity.y;
        }
        else
        {
            rb.gravityScale = gravity;
            rb.linearVelocity = Vector2.zero;
        }

        rb.linearVelocity = Vector2.right * MovHorizontal * velocity.x;
        
      
        if (MovHorizontal == 1)
        {
            _animator.SetBool("IsWalking", true);
            _animator.SetBool("IsIdle", false);
        }
        else if (MovHorizontal == -1)
        {
            _animator.SetBool("IsWalkingB", true);
            _animator.SetBool("IsIdle", false);
        }
        else
        {
            _animator.SetBool("IsWalking", false);
            _animator.SetBool("IsWalkingB", false);
            _animator.SetBool("IsIdle", true);
        }

    }
}
