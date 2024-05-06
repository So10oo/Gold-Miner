using System;
using UnityEngine;

public class Window : MonoBehaviour  
{
    public Action OnOpen;
    public Action OnClose;

    public void Open()
    {
        gameObject.SetActive(true);
        OnOpen?.Invoke();
    }

    public void Close()
    {
        gameObject.SetActive(false);
        OnClose?.Invoke();
    }
}

