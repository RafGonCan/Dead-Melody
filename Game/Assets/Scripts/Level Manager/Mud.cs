using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mud : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player collided with the mud
        if (collision.gameObject.GetComponent<PlayerMovement>()) 
        {
            Debug.Log("Collision with player");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //StartCoroutine(RestartLevel());
        }
    }
    /*
    private IEnumerator RestartLevel() //Restart level after a delay
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    */
}
