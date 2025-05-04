using UnityEngine;

public class GuitarAbility : MonoBehaviour
{
    [SerializeField] private Transform abilityCheckTransform;
    [SerializeField, Range(0f, 100.0f)] private float abilityRadius = 0f;
    [SerializeField] private Animator animatorAffected;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Guitar Ability");
        }   
    }

    private void OnTriggerEnter2D(Collider2D soundArea)
    {
        if (soundArea.GetComponent("Obstacle"))
        {
            Debug.Log("Enemy in range");
        
            if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log("Ability hit");
                animatorAffected.SetBool("UpMovement", true);
            }
            else if (Input.GetButtonDown("Fire1") && animatorAffected.GetBool("UpMovement") == true)
            {
                Debug.Log("Ability hit again");
                animatorAffected.SetBool("DownMovement",true);
                animatorAffected.SetBool("UpMovement", false);
            }
            else if (Input.GetButtonDown("Fire1") && animatorAffected.GetBool("DownMovement") == true)
            {
                Debug.Log("Ability hit again");
                animatorAffected.SetBool("DownMovement", false);
                animatorAffected.SetBool("UpMovement", true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D soundArea)
    {
        if (soundArea.GetComponent("Obstacle"))
        {
            Debug.Log("Enemy out of range");
        }
    }

    void OnDrawGizmos()
    {
        if (abilityCheckTransform != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(abilityCheckTransform.position, abilityRadius);
        }
    }
}
