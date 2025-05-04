using UnityEngine;

public class Size : MonoBehaviour
{
    private Animator _animator;
    private Transform playerTransform;
    [SerializeField]
    private float distanceThreshold = 150f;

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogWarning("Player object not found. Ensure the player has the 'Player' tag.");
        }

        _animator = GetComponent<Animator>();
        if (_animator == null)
        {
            Debug.LogError("Animator component not found on this GameObject.");
        }
    }

    void Update()
    {
        if (playerTransform == null || _animator == null)
        {
            return;
        }

        float distanceToPlayer = Vector2.Distance(playerTransform.position, transform.position);

        if (distanceToPlayer < distanceThreshold)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                bool isSmall = _animator.GetBool("Small");
                _animator.SetBool("Small", !isSmall);
                _animator.SetBool("Normal", isSmall);
            }
        }
    }
}
