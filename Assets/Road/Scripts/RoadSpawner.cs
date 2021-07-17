using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public sealed class RoadSpawner : MonoBehaviour
{
    private static RoadSpawner singleton = null;
    public List<GameObject> _pool = new List<GameObject>();
    public GameObject _roadObj;
    public int _roadCount;
    private Vector3 randDir;
    public Transform creator;

    public static RoadSpawner GetSingleton()
    {
        if (singleton == null)
        {
            singleton = new GameObject("RoadCreator").AddComponent<RoadSpawner>();
        }
        return singleton;
    }

    void Initialize(int count, GameObject roadPref)
    {
        _roadObj = roadPref;
        _roadCount = count;
        InstantiateBlock();
    }

    void InstantiateBlock()
    {
        for (int i = 0; i < _roadCount; i++)
        {
            if (Random.Range(0, 2) == 0)
            {
                randDir = Vector3.forward;
            }
            else
            {
                randDir = Vector3.left;
            }
            
            _roadObj = Instantiate(_roadObj, _roadObj.transform.position + randDir, _roadObj.transform.rotation, creator);
            _pool.Add(_roadObj);
        }
    }
    
}
