using UnityEngine;
using UnityEngine.SceneManagement;

public class Level5 : MonoBehaviour
{
    public void SkipLevels()
    {
        SceneManager.LoadScene(6);
    }
}
