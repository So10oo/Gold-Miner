using UnityEngine;
using Zenject;


public class GameElement : ElementPool
{
    [SerializeField] AudioClip _audioClip;

    [HideInInspector] public float speed;

    SoundPlayer soundPlayer;

    [Inject]
    void Construct(SoundPlayer soundPlayer)
    {
        this.soundPlayer = soundPlayer;
    }

    private void Update()
    {
        var pos = transform.position;
        pos.y -= speed * Time.deltaTime;
        transform.position = pos;
    }

    protected void PlayAudioClip()
    {
        soundPlayer.Play(_audioClip);
    }

}

