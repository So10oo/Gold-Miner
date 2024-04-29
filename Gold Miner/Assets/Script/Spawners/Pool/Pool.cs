using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Pool
{
    IObjectPool<ElementPool> _pool;
    ElementPool _objectPool;

    public Pool(ElementPool objectPool)
    {
        _objectPool = objectPool;
        _pool = new ObjectPool<ElementPool>(Create, OnGet, OnRelease, OnDestroy, true);
    }

    public ElementPool Instantiate()//get
    {
        var elem = _pool.Get();
        elem.inPool = false;
        return elem;
    }

    public ElementPool Instantiate(Vector3 position)
    {
        var elem = Instantiate();
        elem.gameObject.transform.position = position;
        return elem;
    }

    public ElementPool Instantiate(Vector3 position, Quaternion quaternion)
    {
        var elem = Instantiate(position);
        elem.gameObject.transform.rotation = quaternion;
        return elem;
    }

    public ElementPool Instantiate(Vector3 position, Quaternion quaternion, Transform parent, bool worldPositionStays = true)
    {
        var elem = Instantiate(position, quaternion);
        elem.gameObject.transform.SetParent(parent, worldPositionStays);
        return elem;
    }

    public void Destroy(ElementPool obj)//Release
    {
        if (!obj.inPool)
        {
            _pool.Release(obj);
            obj.inPool = true;
        }

    }

    List<ElementPool> list = new();
    public void DestroyAll()
    {
        list.ForEach(obj =>
        {
            if (obj.gameObject.activeSelf)
            {
                _pool.Release(obj);
            }
        });
    }



    void OnRelease(ElementPool obj)
    {
        obj.gameObject.SetActive(false);
    }

    void OnGet(ElementPool obj)
    {
        obj.gameObject.SetActive(true);
    }

    void OnDestroy(ElementPool obj)
    {
        //GameObject.Destroy(obj.gameObject);
    }

    ElementPool Create()
    {
        var item = GameObject.Instantiate(_objectPool);
        item.Init(this);
        list.Add(item);
        return item;
    }

}
