using UnityEngine;

public class Size : MonoBehaviour
{
    private Animator _animator;
    private Transform playerTransform;
    public float distanceThreshold = 150f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector2.Distance(playerTransform.position, transform.position);
        if (distanceToPlayer < distanceThreshold)
        {
            if (Input.GetKey(KeyCode.S) && _animator.GetBool("Small") == false
                && _animator.GetBool("Normal") == false)
            {
                _animator.SetBool("Small", true);
            }
            else if (Input.GetKey(KeyCode.S) && _animator.GetBool("Small") == true
                && _animator.GetBool("Normal") == false)
            {
                _animator.SetBool("Small", false);
                _animator.SetBool("Normal", true);
            }
            else
            {
                _animator.SetBool("Normal", false);
                _animator.SetBool("Small", true);
            }
        }
    }
}
