using System.Xml;
using UnityEngine;

public class MoveDown : MonoBehaviour
{

    private Vector2 gravePos;

    private Transform playerTransform;

    public float distanceThreshold = 5f;

    public float time = 5f;

    public float velocity = 5f;

    public int GravePostion = 100;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        gravePos = gameObject.transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        float distanceToPlayer = Vector2.Distance(playerTransform.position, transform.position);

        if (distanceToPlayer < distanceThreshold)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                if(time == 0)
                {
                    gravePos.y -= GravePostion;
                }
                else
                {
                    time -= 1;
                    gravePos.y -= 1;
                }
            }
        }

    }
}
