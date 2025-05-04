using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Restart"))
        {
            Debug.Log("Restart Level");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
