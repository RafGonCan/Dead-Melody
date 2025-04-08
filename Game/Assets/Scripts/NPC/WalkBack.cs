using System;
using System.Runtime.InteropServices;
using OkapiKit;
using UnityEngine;
using UnityEngine.UIElements;

public class WalkBack : MonoBehaviour
{
    private Transform playerTransform;

    private CapsuleCollider2D collider;

    public float distanceThreshold = 5f;

    private Animator _animator;

    //private PlayerGuitarTrigger GuitarPlayA = new PlayerGuitarTrigger(), GuitarPlayS = new PlayerGuitarTrigger(), GuitarPlayD = new PlayerGuitarTrigger();

    bool guitarA = new PlayerGuitarTrigger();
    bool guitarS = new PlayerGuitarTrigger();
    bool guitarD = new PlayerGuitarTrigger();

    public bool colliderDisabled = false;

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

    // Update is called once per frame
    void Update()
    {

        float distanceToPlayer = Vector2.Distance(playerTransform.position, transform.position);


        //If the player is less then a given distance from the door the door will open if not the door will stay closed
        if (distanceToPlayer < distanceThreshold)
        {

            if (guitarA || guitarD || guitarS)

            {
                if (colliderDisabled == true)
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