using UnityEngine;

public class Size : MonoBehaviour
{
    private Animator _animator;
    private Transform playerTransform;
    [SerializeField]
    private float distanceThreshold = 75f;

    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        _animator = GetComponent<Animator>();
    }

    /*void Update()
    {
        float distanceToPlayer = Vector2.Distance(playerTransform.position, transform.position);

        if (distanceToPlayer < distanceThreshold)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                _animator.SetBool("Small", true);
            }
            if (_animator.GetBool("Small") == true && Input.GetButtonDown("Fire1"))
            {
                _animator.SetBool("Small", false);
            }
        }
    }*/
    void Update()
    {
        if (playerTransform == null || _animator == null)
        {
            return;
        }

        float distanceToPlayer = Vector2.Distance(playerTransform.position, transform.position);

        if (distanceToPlayer < distanceThreshold)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                bool isSmall = _animator.GetBool("Small");
                _animator.SetBool("Small", !isSmall);
                //_animator.SetBool("Small", isSmall);
            }
        }
    }
}
