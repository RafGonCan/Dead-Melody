using JetBrains.Annotations;
using OkapiKit;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class Door : MonoBehaviour
{
    private Animator _animator;

    //Getting player position
    private Transform playerTransform;

    private PlayerGuitarTrigger GuitarPlayA;

    //Getting collider from door
    private BoxCollider2D collider;

    public float distanceThreshold = 5f;
    
    private void Start()
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

    private void Update()
    {
        if (playerTransform != null)
        {


            float distanceToPlayer = Vector2.Distance(playerTransform.position, transform.position);


            //If the player is lees then a given distance from the door the door will open if not the door will stay closed
            if (distanceToPlayer < distanceThreshold)
            {

                if (GuitarPlayA)

                {
                    Vector2 scale = defaultScale;
                    scale.x = scale.x * 3.0f;

                    collider.enabled = false;

                    _animator.SetTrigger("DoorTrigger");
                    var a = _animator.GetCurrentAnimatorStateInfo(0);

                    if (a.IsName("Door idle open") == true)
                    {

                        collider.enabled = true;

                    }
                }
            }
        }
    }
}
