using UnityEngine;
using YG;

public abstract class AudioSwitch : MonoBehaviour
{
    [SerializeField] protected AudioSource _audioSource;
    [SerializeField] protected CheckBoxView _checkBoxView;

    public abstract bool Mute
    {
        get;
        set;
    }

    // Подписываемся на событие GetDataEvent в OnEnable
    private void OnEnable() => YandexGame.GetDataEvent += Load;
    // Отписываемся от события GetDataEvent в OnDisable
    private void OnDisable() => YandexGame.GetDataEvent -= Load;


    public void Start()
    {
        if (YandexGame.SDKEnabled)
            Load();

        if (_audioSource.clip != null)
            _audioSource.Play();
    }

    public void Switch()
    {
        Mute = !Mute;
    }

    protected abstract void Load();

}
