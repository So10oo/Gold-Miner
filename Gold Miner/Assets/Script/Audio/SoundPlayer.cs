using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;

    public void Play(AudioClip clip)
    {
        _audioSource.clip = clip;
        _audioSource.Play();
    }

}
