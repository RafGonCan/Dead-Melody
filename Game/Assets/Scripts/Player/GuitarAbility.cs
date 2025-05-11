using UnityEngine;

public class GuitarAbility : MonoBehaviour
{
    [SerializeField] private Transform abilityCheckTransform;
    [SerializeField, Range(0f, 100.0f)] private float abilityRadius = 0f;
    [SerializeField] private Animator animatorAffected;
    [SerializeField] private ParticleSystem soundWaveArea;

    // Update is called once per frame
    void Update()
    {
        // Play sound if "Fire1" was pressed
        if (Input.GetButton("Fire1"))
        {
            Debug.Log("Guitar Ability");
            soundWaveArea.Play();
        }   
    }

    private void OnTriggerEnter2D(Collider2D soundArea)
    {
        // check if the Obstacle is in range
        if (soundArea.GetComponent<Obstacle>())
        {
            Debug.Log("Enemy in range");
            // If in range and pressed "Fire1" make box move up
            if (Input.GetButton("Fire1"))
            {
                Debug.Log("Ability hit");
                animatorAffected.SetBool("UpMovement", true);
            }
            // If in range, pressed "Fire1" and box up, move box down
            else if (Input.GetButton("Fire1") && animatorAffected.GetBool("UpMovement") == true)
            {
                Debug.Log("Ability hit again");
                animatorAffected.SetBool("DownMovement",true);
                animatorAffected.SetBool("UpMovement", false);
            }
            else if (Input.GetButton("Fire1") && animatorAffected.GetBool("DownMovement") == true)
            {
                Debug.Log("Ability hit again");
                animatorAffected.SetBool("DownMovement", false);
                animatorAffected.SetBool("UpMovement", true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D soundArea)
    {
        // check if Obstacle get out of range
        if (soundArea.GetComponent<Obstacle>())
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
