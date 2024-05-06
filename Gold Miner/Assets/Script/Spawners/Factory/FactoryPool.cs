using UnityEngine;
using Zenject;

public class FactoryPool : IFactoryPool
{
    DiContainer _diContainer;

    public FactoryPool(DiContainer diContainer)
    {
        _diContainer = diContainer;
    }

    public ElementPool Create(ElementPool gameObject)
    {
        return _diContainer.InstantiatePrefabForComponent<ElementPool>(gameObject);
    }
}

