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
        if (Input.GetButtonDown("Cancel"))
        {
            Debug.Log("Open pause menu");
            PauseMenu.SetActive(true);
        }
    }
}
