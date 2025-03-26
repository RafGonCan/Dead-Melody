using System.Xml;
using Unity.VisualScripting;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    private Transform playerTransform;

    public float distanceThreshold = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
    }


    // Update is called once per frame
    void Update()
    {

        float distanceToPlayer = Vector2.Distance(playerTransform.position, transform.position);

        if (distanceToPlayer < distanceThreshold)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                GetComponent<Rigidbody2D>().gravityScale = 1f;
            }
        }

    }
}
