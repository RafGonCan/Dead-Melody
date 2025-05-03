using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButton("Restart"))
        {
            Debug.Log("Restart level");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
