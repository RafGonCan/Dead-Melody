using UnityEngine;

public class CloudAnimParallax : MonoBehaviour
{
    [SerializeField] private Animator cloudsAnimator;

    private Vector3 startPos;
    private float width;

    void Start()
    {
        if (cloudsAnimator == null)
            cloudsAnimator = GetComponent<Animator>();

        startPos = transform.position;
        width = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
       

        if (transform.position.x < startPos.x - width)
        {
            transform.position = startPos;
            cloudsAnimator.Play(0); 
        }
    }
}

