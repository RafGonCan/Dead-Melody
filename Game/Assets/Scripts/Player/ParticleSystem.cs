using UnityEngine;

public class DeathParticleSystem : MonoBehaviour
{
    private Mud deathCheck;

    private PlayerMovement playerMovement;

    [SerializeField] private ParticleSystem deathParticleEnable;

    [SerializeField] private SpriteRenderer spriteRenderer;

    void Start()
    {
        FindAnyObjectByType<Mud>();
        GetComponent<ParticleSystem>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

        if (deathCheck == null)
        {
            deathCheck = FindAnyObjectByType<Mud>();
        }

        if (deathCheck != null && deathCheck.deathParticlesCheck)
        {
            deathParticleEnable.Play();
            spriteRenderer.enabled = false;
            playerMovement.enabled = false;
        }
    }
}
