using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector2 velocity;

    [SerializeField] private string horizontalInputName = "Horizontal";

    [SerializeField] private string verticalInputName = "Vertical";

    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        float MovHorizontal = Input.GetAxis(horizontalInputName);
        float MovVertical = Input.GetAxis(verticalInputName);


        rb.linearVelocity = Vector2.right * MovHorizontal * velocity.x;
    }
}
