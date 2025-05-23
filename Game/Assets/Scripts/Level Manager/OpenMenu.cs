using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu;
    private Animator[] animators;

    void Start()
    {
        animators = pauseMenu.GetComponentsInChildren<Animator>();
        pauseMenu.SetActive(false);
    }
    void Update()
    {
        // Pause the game
        if (Input.GetButtonDown("Cancel"))
        {
            Debug.Log("Open pause menu");
            Time.timeScale = 0f;
            foreach (Animator animator in animators)
            {
                animator.ResetTrigger("Pressed");
            }
            pauseMenu.SetActive(true);
        }
    }

    public void Resume()
    {
        // Resume the game
        Debug.Log("Close pause menu");
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
