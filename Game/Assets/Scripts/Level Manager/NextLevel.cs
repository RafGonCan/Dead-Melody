using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>())
        {
            StartCoroutine(LoadNextLevel());
        }
    }

    private IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds (0.05f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        /*if (SceneManager.GetActiveScene().buildIndex == 13)
        {
            yield return new WaitForSeconds (0.05f);
            SceneManager.LoadScene(0);
        }

        else
        {
            yield return new WaitForSeconds (0.05f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }*/
    }
}
