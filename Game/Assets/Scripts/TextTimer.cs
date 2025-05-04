using UnityEngine;
using UnityEngine.Rendering;

public class Timer : MonoBehaviour
{
    [SerializeField, Range(0.0f,60.0f)] private float delay;

    [SerializeField] GameObject MiniText;

    void Update()
    {
        delay -= Time.deltaTime; // Decrease the delay

        if (delay <= 0.0f)
        {
            delay = 0.0f; // Prevents the timer from going negative
            Destroy(this.gameObject);
            MiniText.SetActive(true);
        }
    }
}
