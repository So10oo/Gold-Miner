using System;
using UnityEngine;
using UnityEngine.UI;


public class CheckBoxView : View<bool>
{
    [SerializeField] Image _image;
    [SerializeField] Sprite Off;
    [SerializeField] Sprite On;

    public override void ViewData(bool data)
    {
        if (data)
        {
            _image.sprite = Off;
        }
        else
        {
            _image.sprite = On;
        }
    }
}

