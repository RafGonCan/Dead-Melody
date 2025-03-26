using UnityEngine;

public class PlataformEnemy : MonoBehaviour
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
        _animator = GetComponent<Animator>();
    }

    public Vector2 PlataformEnemyPosition;

    // Update is called once per frame
    void Update()
    {
        PlataformEnemyPosition = gameObject.transform.position;

        float distanceToPlayer = Vector2.Distance(playerTransform.position, transform.position);

        if (distanceToPlayer < distanceThreshold)
        {
            if (Input.GetKeyDown(KeyCode.J) && _animator.GetBool("Small") == false)
            {
                _animator.SetBool("Small", true);
            }
            else if (Input.GetKeyDown(KeyCode.J) && _animator.GetBool("Normal") == false)
            {
                _animator.SetBool("Normal", true);
            }

        }
    }
}
