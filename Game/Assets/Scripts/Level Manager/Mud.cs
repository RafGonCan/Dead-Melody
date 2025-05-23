using System.Collections;
using OkapiKit.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mud : MonoBehaviour
{
    [SerializeField, Range(0.0f, 60.0f)] private float delay;

    private SoundManager soundManager;

    private bool collided = false;

    public bool deathParticlesCheck = false;

    private void Start()
    {
        // Find the SoundManager in the scene
        soundManager = FindAnyObjectByType<SoundManager>();
    }

    private void Update()
    {

        if (collided)
        {
            delay -= Time.deltaTime;
        }
        if (delay <= 0.0f && collided)
        {
            delay = 0.0f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        soundManager.SFXPlay(0);

        deathParticlesCheck = true;

        collided = true;
        /*
        if (delay <= 0.0f && collision.gameObject.GetComponent<PlayerMovement>())
        {
            Debug.Log("Collision with player");
            delay = 0.0f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }*/

        /*
        // Check if the player collided with the mud
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            Debug.Log("Collision with player");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //StartCoroutine(RestartLevel());
        }*/
    }
    /*
    private IEnumerator RestartLevel() //Restart level after a delay
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    */
}
