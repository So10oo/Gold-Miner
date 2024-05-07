using System;
using UnityEngine;
using Zenject;

public class Wallet : MonoBehaviour
{
    [SerializeField] Transform _walletTransform;

    public Transform walletTransform =>_walletTransform;

    public Action<int> OnCoinsValueChange;

    private int _coins = 0;
    public int Coins 
    {  
        get
        {
            return _coins;
        }
        private set
        {
            _coins = value;
            OnCoinsValueChange?.Invoke(value);
        } 
    }

    [Inject]
    void Construct(ProgressGame progressGame)
    {
        progressGame.OnStartGameAction += ResetCoins;
    }

    public void AddCoin() => Coins++;

    public void ResetCoins() => Coins = 0;

}
