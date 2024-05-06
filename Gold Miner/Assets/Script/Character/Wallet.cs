using System;
using UnityEngine;
using Zenject;

public class Wallet : MonoBehaviour, ISaveLoad
{
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

    public void Load()
    {
        Debug.Log("Load");
    }

    public void Save()
    {
        Debug.Log("Save");
    }
}
