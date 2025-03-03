using JetBrains.Annotations;
using Unity.Collections;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.UIElements;

public class Door : MonoBehaviour
{
    private Animator _animator;
    private Transform playerTransform;

    private BoxCollider2D collider;

    public float distanceThreshold = 5f;
    private bool isPlayerInRange = false;



    private void Start()
    {
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


            if (distanceToPlayer < distanceThreshold)
            {
                if (Input.GetKey(KeyCode.C))
                {
                    Vector2 scale = defaultScale;
                    scale.x = scale.x * 3.0f;
                    collider.enabled=false;
                }
            }
        }
    }
}
