using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //private AudioMixer audioMixer;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource[] musicSource;

    [SerializeField] private AudioSource[] SFXSource;

    [SerializeField] private AudioSource[] KeyInput;

    [Header("Indexes")]
    [SerializeField] private int musicIndex = 0;
    [SerializeField] private int sfxIndex = 0;

    [Header("Pitch Settings")]
    [SerializeField] private float pitchChangeSpeed = 0.1f;
    [SerializeField] private float minPitch = 0.5f;
    [SerializeField] private float maxPitch = 2.0f;
    private float pitchDirection = 1f;

    void Start()
    {

        if (musicSource == null)
        {
            musicSource = GetComponents<AudioSource>();
        }

        if (SFXSource == null)
        {
            SFXSource = GetComponents<AudioSource>();
        }

        PlayMusic(musicIndex);

    }

    void Update()
    {
        if (musicSource != null && musicSource.Length > 0 && musicSource[musicIndex] != null && musicSource[musicIndex].isPlaying)
        {
            musicSource[musicIndex].pitch += pitchChangeSpeed * pitchDirection * Time.deltaTime;

            if (musicSource[musicIndex].pitch > maxPitch)
            {
                float overflow = musicSource[musicIndex].pitch - maxPitch;
                musicSource[musicIndex].pitch = minPitch + overflow;
            }
            else if (musicSource[musicIndex].pitch < minPitch)
            {
                float underflow = minPitch - musicSource[musicIndex].pitch;
                musicSource[musicIndex].pitch = maxPitch - underflow;
            }
        }

        if (musicSource != null && musicSource.Length > 0 && musicSource[musicIndex] != null && musicSource[musicIndex].clip != null && !musicSource[musicIndex].isPlaying)
        {
            musicSource[musicIndex].Play();
        }


    }

    public void SFXPlay(int sfxIndex)
    {
        if (SFXSource != null && SFXSource.Length > 0 && SFXSource[sfxIndex] != null)
        {
            SFXSource[sfxIndex].Play();
        }
        else
        {
            Debug.LogWarning("SFXSource is not set or index is out of range.");
        }
    }

    public void KeyInputPlay(int keyInputIndex)
    {
        if (KeyInput != null && KeyInput.Length > 0 && KeyInput[keyInputIndex] != null && Input.GetKeyDown(KeyCode.Space))
        {
            KeyInput[keyInputIndex].Play();
        }
        else
        {
            Debug.LogWarning("KeyInput is not set or index is out of range.");
        }

    }

    public void PlayMusic(int index)
    {

        if (musicSource != null && musicIndex >= 0 && musicIndex < musicSource.Length && musicSource[musicIndex] != null)
        {
            musicSource[musicIndex].Play();
        }

        else
        {
            Debug.LogWarning("Invalid music index or MusicSource/MusicClips not set.");
        }
    }


    public void PitchChanger(int index)
    {
        if (musicSource != null && index >= 0 && index < musicSource.Length && musicSource != null)
        {
            if (musicSource != null && musicIndex >= 0 && musicIndex < musicSource.Length && musicSource[musicIndex] != null)
            {
                musicSource[musicIndex].Play();
                if (musicSource[musicIndex].pitch < minPitch || musicSource[musicIndex].pitch > maxPitch)
                {
                    float range = maxPitch - minPitch;
                    musicSource[musicIndex].pitch = minPitch + Mathf.Repeat(musicSource[musicIndex].pitch - minPitch, range);
                }
            }
        }
        else
        {
            Debug.LogWarning("Invalid music index or MusicSource/MusicClips not set.");
        }
    }


}
