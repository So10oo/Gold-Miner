using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinChange : MonoBehaviour
{
    [SerializeField] SpriteRenderer _skin;
    [SerializeField] Sprite _sprite;

    private void Awake()
    {
        GetComponent<Wallet>().OnCoinsValueChange += SetSkin;
    }


    void SetSkin(int value)
    {
        if (value == 1)
            _skin.sprite = _sprite;
    }


}
