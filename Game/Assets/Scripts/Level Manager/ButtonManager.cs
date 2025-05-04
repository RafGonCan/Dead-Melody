using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonManager : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitButton()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }
}
