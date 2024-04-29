using UnityEngine;

public class Bomb : GameElement
{
    [SerializeField] GameObject _explosion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<HealthPoints>() is HealthPoints charactet)
        {
            charactet.Die();
            var explosion = Instantiate(_explosion, collision.gameObject.transform.position, Quaternion.identity);
            PlayAudioClip();
            Destroy(explosion, 0.5f);
        }
        else
            this.Destroy();
    }
 
}

