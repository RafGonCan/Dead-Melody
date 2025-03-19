using System;
using OkapiKit;
using UnityEngine;

public class WalkBack : MonoBehaviour
{
    private Transform playerTransform;


    private CapsuleCollider2D collider;

    public float distanceThreshold = 5f;
    private Animator _animator;

    public bool inputTrueA = false;
    public bool inputTrueS = false;
    public bool inputTrueD = false;

    public bool colliderEnable = false;

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

<<<<<<< HEAD
            if (inputTrueJ == true && Input.GetKeyDown(KeyCode.J) ||

            inputTrueK == true && Input.GetKeyDown(KeyCode.K) ||

            inputTrueL == true && Input.GetKeyDown(KeyCode.L))
=======
            if (inputTrueA == true && Input.GetKey(KeyCode.A) ||

            inputTrueS == true && Input.GetKey(KeyCode.S) ||

            inputTrueD == true && Input.GetKey(KeyCode.D))
>>>>>>> e8c1c61825d460fbdd8abd5e0198ae46769f2daf

            {
                if (colliderEnable == true)
                {

                    collider.enabled = false;

                }
                
                _animator.SetTrigger("MoveTrigger");

                var a = _animator.GetCurrentAnimatorStateInfo(0);

                if (a.IsName("MoveBack"))
                {

                    collider.enabled = true;

                }

            }
        }
    }
}