using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
/*
internal class Pool
{
    private GameObject _prefab;
    private IObjectPool<GameObject> _pool;

    private Transform _root;
    private Transform Root
    {
        get
        {
            if(_root == null)
            {
                var go = new GameObject() { name = $"@{_prefab.name}Pool" };
                _root = go.transform;
            }
            return _root;
        }
    }

    public Pool(GameObject prefab)
    {
        _prefab = prefab;
        _pool = new ObjectPool<GameObject>(OnCreate, OnGet, OnRelease, OnDestroy);
    }

    public void Push(GameObject go)
    {
        if (go.activeSelf)
            _pool.Release(go);
    }

    public GameObject Pop()
    {
        return _pool.Get();
    }
}
*/
public class PoolManager
{
    //private Dicitionary<string, Pool> _pools = new Dicitionary<string, Pool>();
}
