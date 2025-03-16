using System;
using OkapiKit;
using UnityEngine;

public class WalkBack : MonoBehaviour
{
    private Transform playerTransform;

    private Animator _animator;

    private CapsuleCollider2D collider;


    public float distanceThreshold = 5f;

    public bool inputTrueJ = false;
    public bool inputTrueK = false;
    public bool inputTrueL = false;

    void Start()
    {
        //Variable that connects the player position to the door
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }

        _animator = GetComponent<Animator>();

        collider = GetComponent<CapsuleCollider2D>();
    }

    Vector2 defaultScale;

    // Update is called once per frame
    void Update()
    {

        float distanceToPlayer = Vector2.Distance(playerTransform.position, transform.position);


        //If the player is lees then a given distance from the door the door will open if not the door will stay closed
        if (distanceToPlayer < distanceThreshold)
        {

            if (inputTrueJ == true && Input.GetKey(KeyCode.J) ||

            inputTrueK == true && Input.GetKey(KeyCode.K) ||

            inputTrueL == true && Input.GetKey(KeyCode.L))

            {

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