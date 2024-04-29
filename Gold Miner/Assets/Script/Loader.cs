using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Loader : MonoBehaviour
{
    [SerializeField] UnityEvent OnLoad;

    [SerializeField] GameObject[] _loadObjects;

    void Start()
    {
        StartCoroutine(Load());
    }

    IEnumerator Load()
    {
        foreach (var obj in _loadObjects) 
        {
            obj.SetActive(true);
        }
        yield return null;
        foreach (var obj in _loadObjects)
        {
            obj.SetActive(false);
        }
        OnLoad.Invoke();
    }

 
}
