using System;
using UnityEngine;
using UnityEngine.Events;


public class HealthPoints : MonoBehaviour
{
    [SerializeField] UnityEvent OnDie;

    public Action onDie;

    public void Die()
    {
        OnDie?.Invoke();
        onDie?.Invoke();
    }
}

