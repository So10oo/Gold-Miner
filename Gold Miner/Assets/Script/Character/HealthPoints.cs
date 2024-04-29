using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

