using DG.Tweening;
using UnityEngine;

public class Coin : FallElement
{
    Collider2D _collider;
    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var wallet = collision.gameObject.GetComponent<Wallet>();
        if (wallet != null)
        {
            wallet.AddCoin();
            PlayAudioClip();
            PlayAnimation(wallet.walletTransform);
        }
        else
            this.Release();
    }

    void PlayAnimation(Transform target)
    {
        _collider.enabled = false;
        canMove = false;

        gameObject.transform.SetParent(target.parent, true);
        float time = 0.5f;
        transform.DOLocalJump(target.localPosition, 1, 1, time).OnComplete(Release);
        transform.DOScale(0.5f, time);
    }

    protected override void OnGetInPool()
    {
        gameObject.transform.localScale = Vector3.one;
        _collider.enabled = true;
        canMove = true;
        gameObject.transform.parent = null; 
    }
}

