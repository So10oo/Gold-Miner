using UnityEngine;

public class AudioSwitch : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    [SerializeField] CheckBoxView _checkBoxView;

    bool _isPlayed = true;
    bool IsPlayed
    {
        get { return _isPlayed; }
        set
        {
            _isPlayed = value;
            PlayerPrefs.SetString(gameObject.name, _isPlayed.ToString());
            _checkBoxView.ViewData(_isPlayed);
            _audioSource.mute = !_isPlayed;
        }
    }

    public void StartAudio()
    {
        IsPlayed = bool.Parse(PlayerPrefs.GetString(gameObject.name, true.ToString()));
        if(_audioSource.clip!= null)
            _audioSource.Play();
    }

    public void Switch()
    {
        IsPlayed = !IsPlayed;
    }
}
