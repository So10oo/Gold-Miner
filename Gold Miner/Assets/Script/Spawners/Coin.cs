using UnityEngine;

public class Coin : GameElement
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var wallet = collision.gameObject.GetComponent<Wallet>();
        if (wallet != null)
        {
            wallet.AddCoin();
            PlayAudioClip();
        }
        this.Destroy();
    }


}

