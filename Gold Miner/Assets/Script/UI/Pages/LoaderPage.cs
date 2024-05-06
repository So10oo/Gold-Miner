using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class LoaderPage : Page
{
    [SerializeField] UnityEvent OnLoad;

    [SerializeField] GameObject[] _loadObjects;

    IEnumerator Load()
    {
        //foreach (var obj in _loadObjects) 
        //{
        //    obj.SetActive(true);
        //}
        yield return null;
        //foreach (var obj in _loadObjects)
        //{
        //    obj.SetActive(false);
        //}
        OnLoad.Invoke();
    }

    public override void Enter()
    {
        base.Enter();
        StartCoroutine(Load());
    }


}
