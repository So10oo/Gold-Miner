using DG.Tweening;
using UnityEngine;

public class Coin : GameElement
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
        //gameObject.transform.parent = target.parent;
        gameObject.transform.SetParent(target.parent, true);

        float time = 0.5f;
        transform.DOLocalJump(target.localPosition, 1, 1, time).OnComplete(Release);
        transform.DOScale(0.5f, time);
       
        //DOTween.To(() => transform.position, x => transform.position = x,) ;
        //DOTween.To(() => myVector, x => myVector = x, new Vector3(3, 4, 8), 1);
        //DOTween.Sequence()
        //    .Append(transform.DOJump(target.position,1,1,0.5f))
        //    .Append()
    }

    protected override void OnGetInPool()
    {
        gameObject.transform.localScale = Vector3.one;
        _collider.enabled = true;
        canMove = true;
        gameObject.transform.parent = null; 
    }
}

