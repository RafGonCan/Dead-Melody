using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject controlsMenu;
    private Animator[] animators;

    void Start()
    {
        animators = controlsMenu.GetComponentsInChildren<Animator>();
        controlsMenu.SetActive(false);
    }

    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void ControlsMenu()
    {
        Time.timeScale = 0f;
        foreach (Animator animator in animators)
        {
            animator.ResetTrigger("Pressed");
        }
        controlsMenu.SetActive(true);
    }

    public void BackButton()
    {
        Time.timeScale = 1.0f;
        controlsMenu.SetActive(false);
    }

    public void QuitButton()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }
}
