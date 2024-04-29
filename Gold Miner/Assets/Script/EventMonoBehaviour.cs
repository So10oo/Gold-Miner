using UnityEngine;
using UnityEngine.Events;

public class EventMonoBehaviour : MonoBehaviour
{
    [SerializeField] UnityEvent _start;

    void Start()
    {
        _start?.Invoke();
    }

}
