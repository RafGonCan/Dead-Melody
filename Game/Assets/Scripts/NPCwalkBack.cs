using OkapiKit;
using UnityEngine;

public class NPCwalkBack : MonoBehaviour
{
    private Transform playerTransform;

    private Animator _animator;

    private BoxCollider2D collider;


    public float distanceThreshold = 5f;

    void Start()
    {
        //Variable that connects the player position to the door
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }

        _animator = GetComponent<Animator>();

        collider = GetComponent<BoxCollider2D>();
    }

    Vector2 defaultScale;

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector2.Distance(playerTransform.position, transform.position);


       
        if (distanceToPlayer < distanceThreshold)
        {

            if (Input.GetKey(KeyCode.C))

            {
                Vector2 scale = defaultScale;
                scale.x = scale.x * 3.0f;

                collider.enabled = false;

                _animator.SetTrigger("MoveTrigger");
                var a = _animator.GetCurrentAnimatorStateInfo(0);

                if (a.IsName("MoveBack") == true)
                {

                    collider.enabled = true;

                }

            }
        }
    }
}