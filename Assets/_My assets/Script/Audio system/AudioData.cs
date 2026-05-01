using UnityEngine;

[CreateAssetMenu (fileName = "Audio data", menuName = "Scriptable/Audio data")]
public class AudioData : ScriptableObject
{
    public AudioClip bgMusic;
    public AudioClip buttonSfx;
    public AudioClip levelCompleteSfx;
}
