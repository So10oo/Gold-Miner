using TMPro;
using UnityEngine;

public class WalletView : View<int>
{
    [SerializeField] Wallet _wallet;
    [SerializeField] TextMeshProUGUI _text;

    private void Awake()
    {
        _wallet.OnCoinsValueChange += ViewData;
    }

    public override void ViewData(int data)
    {
        _text.text = data.ToString();
    }

    private void OnEnable()
    {
        _text.text = _wallet.Coins.ToString();
    }
}
