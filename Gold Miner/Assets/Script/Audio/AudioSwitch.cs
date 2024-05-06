using UnityEngine;

public class AudioSwitch : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    [SerializeField] CheckBoxView _checkBoxView;

    bool _mute;
    public bool Mute
    {
        get { return _mute; }
        set
        {
            _mute = value;
            PlayerPrefs.SetString(gameObject.name, _mute.ToString());
            _checkBoxView.ViewData(_mute);
            _audioSource.mute = !_mute;
        }
    }

    public void Start()
    {
        Mute = bool.Parse(PlayerPrefs.GetString(gameObject.name, true.ToString()));
        if (_audioSource.clip != null)
            _audioSource.Play();
    }

    public void Switch()
    {
        Mute = !Mute;
    }
}
