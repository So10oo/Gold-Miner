using UnityEngine;
using Zenject;

public class SkinChange : MonoBehaviour
{
    [SerializeField] Sprite _defaultSkin;
    [SerializeField] Sprite _goldSkin;
    [SerializeField] SpriteRenderer _skin;

    [Inject]
    void Construct(ProgressGame progressGame)
    {
        progressGame.OnStartGameAction += () => _skin.sprite = _defaultSkin;
    }

    private void Awake()
    {
        GetComponent<Wallet>().OnCoinsValueChange += SetSkin;
    }

    void SetSkin(int value)
    {
        if (value == 1)
            _skin.sprite = _goldSkin;
    }
}
