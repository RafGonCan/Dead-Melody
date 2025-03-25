using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public Vector2 playerPos;

    public void Update()
    {
        playerPos = gameObject.transform.position;
    }
}
