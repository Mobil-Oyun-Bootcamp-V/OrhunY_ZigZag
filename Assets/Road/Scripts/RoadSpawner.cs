using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public  class RoadSpawner : MonoBehaviour
{
    public List<GameObject> _pool = new List<GameObject>();
    public GameObject _roadObj;
    public int _roadCount;
    private Vector3 randDir;

    private void Start()
    {
        Initialize(_roadCount);
    }

    public void Initialize(int count)
    {
        _roadCount = count;
        InstantiateBlock();
    }

    //Creates new road object at random given directions.
    public void InstantiateBlock()
    {
        for (var i = 0; i < _roadCount; i++)
        {
            if (Random.Range(0, 2) == 0)
                randDir = Vector3.forward;
            else
                randDir = Vector3.left;

            _roadObj = Instantiate(_roadObj, _roadObj.transform.position + randDir, _roadObj.transform.rotation,
                transform);
            _pool.Add(_roadObj);
        }
    }
}