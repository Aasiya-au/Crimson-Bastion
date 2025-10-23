using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    private AudioSource audioSource;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // survives scene changes
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        else Destroy(gameObject);
    }

    public void Play(AudioClip clip)
    {
        if (clip != null) audioSource.PlayOneShot(clip);
    }
}
