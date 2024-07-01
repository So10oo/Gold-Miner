using System;
using UnityEngine;
using UnityEngine.Events;

public class Window : MonoBehaviour  
{
    public UnityEvent OnOpen;
    public UnityEvent OnClose;

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

