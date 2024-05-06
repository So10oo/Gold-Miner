using UnityEngine;

public interface IFactoryPool
{
    ElementPool Create(ElementPool gameObject);
}
