using UnityEngine;
using UnityEngine.Events;

public class Initialization : MonoBehaviour
{
    [SerializeField] UnityEvent _initialization;

    void Start()
    {
        _initialization?.Invoke();
    }

}
