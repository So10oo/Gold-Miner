using System;
using UnityEngine;
using UnityEngine.Events;


public class Page : MonoBehaviour, IState
{
    [SerializeField] UnityEvent onEnterPage;
    [SerializeField] UnityEvent onExitPage;

    public virtual void Enter()
    {
        onEnterPage?.Invoke();
        gameObject.SetActive(true);
    }

    public virtual void Exit()
    {
        onExitPage?.Invoke();
        gameObject.SetActive(false);
    }
}

