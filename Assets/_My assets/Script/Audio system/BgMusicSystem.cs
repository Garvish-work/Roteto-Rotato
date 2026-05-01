using UnityEngine;

public class BgMusicSystem : MonoBehaviour
{
    AudioSource audioSource;

    public static BgMusicSystem instance;
    [SerializeField] private AudioData audioData;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
            PlayBgMusic();
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void PlayBgMusic()
    {
        audioSource.clip = audioData.bgMusic;
        audioSource.loop = true;
        audioSource.Play();
    }
}
