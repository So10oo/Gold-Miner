using UnityEngine;


public class GameElement : ElementPool
{
    [SerializeField] AudioClip _audioClip;

    [HideInInspector] public float speed;

    private void Update()
    {
        var pos = transform.position;
        pos.y -= speed * Time.deltaTime;
        transform.position = pos;
    }

    protected void PlayAudioClip()
    {
        var audioSource = Camera.main.gameObject.GetComponent<AudioSource>();
        //if (!audioSource.isPlaying)
        //{
            audioSource.clip = _audioClip;
            audioSource.Play();
       // }
    }

}

