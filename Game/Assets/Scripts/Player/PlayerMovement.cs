using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector2 velocity;

    [SerializeField] private string horizontalInputName = "Horizontal";

    [SerializeField] private float gravity = 0;

    private Rigidbody2D rb;
    
    private Animator _animator;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

        _animator = GetComponent<Animator>();
    }


    void Update()
    {
        float MovHorizontal = Input.GetAxis(horizontalInputName);
         
        rb.linearVelocity = new Vector2(MovHorizontal * velocity.x, rb.linearVelocity.y - gravity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(rb.linearVelocity.x, velocity.y), ForceMode2D.Impulse);
        }
      
        if (MovHorizontal >= 0.1f)
        {
            _animator.SetBool("IsWalking", true);
            _animator.SetBool("IsIdle", false);
        }
        else if (MovHorizontal <= -0.1f)
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
