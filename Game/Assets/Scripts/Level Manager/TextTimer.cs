using UnityEngine;
using UnityEngine.Rendering;

public class Timer : MonoBehaviour
{
    [SerializeField, Range(0.0f,60.0f)] private float delay;

    [SerializeField] GameObject nextText;

    void Start()
    {
        // Hide the text at the start
        nextText.SetActive(false);
    }
    void Update()
    {
        // Decrease the delay timer
        delay -= Time.deltaTime;

        // Prevents the timer from going negative
        if (delay <= 0.0f)
        {
            delay = 0.0f;
            Destroy(this.gameObject);
            nextText.SetActive(true);
        }
    }
}
