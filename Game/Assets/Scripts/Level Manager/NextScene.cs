using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(LoadNextLevel());
    }

    private IEnumerator LoadNextLevel()
    {
        // if buildIndex == x then load Main Menu
        if (SceneManager.GetActiveScene().buildIndex == 13)
        {
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(0);
        }
        else
        {
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
