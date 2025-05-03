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
        //GameObject tutorialMenu = GameObject.Find("Tutorial Canvas");
    }

    public void QuitButton()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }
}
