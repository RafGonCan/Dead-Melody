using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>())
        {
            StartCoroutine(LoadLastLevel());
        }
    }

    private IEnumerator LoadLastLevel()
    {
            yield return new WaitForSeconds (0.05f);
            SceneManager.LoadScene(7);
    
    }
}
