using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SaveLoadService : MonoBehaviour
{
    [Inject]
    void Construct(List<ISaveLoad> items)
    {
        if (items!=null)
        {
            Debug.Log("works!");
        }
    }


    
}
