using System;
using UnityEngine;

public class Wallet : MonoBehaviour
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

    public void AddCoin() => Coins++;
    
    public void ResetCoins() => Coins = 0;

    
}
