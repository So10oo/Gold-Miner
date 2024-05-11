using UnityEngine;
using Zenject;


public class FallElement : ElementPool
{
    [SerializeField] AudioClip _audioClip;

    [HideInInspector] public float speed;

    SoundPlayer soundPlayer;

    protected bool canMove = true;

    [Inject]
    void Construct(SoundPlayer soundPlayer)
    {
        this.soundPlayer = soundPlayer;
    }

    private void Update()
    {
        if (!canMove)
            return;

        var pos = transform.position;
        pos.y -= speed * Time.deltaTime;
        transform.position = pos;
    }

    protected void PlayAudioClip()
    {
        soundPlayer.Play(_audioClip);
    }

}

