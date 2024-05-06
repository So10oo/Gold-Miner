using UnityEngine;
using UnityEngine.Events;


public class HealthPoints : MonoBehaviour
{
    [SerializeField] UnityEvent OnDie;

    public void Die()
    {
        OnDie?.Invoke();
    }
}

