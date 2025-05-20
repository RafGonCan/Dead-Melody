using TMPro;
using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject PauseMenu;

    void Start()
    {
        if (PauseMenu == null)
        {
            return;
        }
    }
    void Update()
    {
        // Pause the game
        if (Input.GetButton("Cancel"))
        {
            Debug.Log("Open pause menu");
            PauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void Continue()
    {
        // Resume the game
        Debug.Log("Close pause menu");
        PauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
