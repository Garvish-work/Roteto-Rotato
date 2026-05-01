using UnityEngine;

public class SfxSystem : MonoBehaviour
{
    AudioSource sfxAudioSource;
    [SerializeField] private AudioData audioData;

    private void Awake()
    {
        sfxAudioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        AudioActions.PlaySfx += OnPlaySfx;
    }

    private void OnDisable()
    {
        AudioActions.PlaySfx -= OnPlaySfx;
    }

    private void OnPlaySfx(SfxType sfxType)
    {
        switch (sfxType)
        {
            case SfxType.BUTTON:
                sfxAudioSource.PlayOneShot(audioData.buttonSfx);
                break;
            case SfxType.LEVEL_COMPLETE:
                sfxAudioSource.PlayOneShot(audioData.levelCompleteSfx);
                break;
        }
    }
}

public enum SfxType
{
    BUTTON,
    LEVEL_COMPLETE
}
