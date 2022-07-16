using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {
    public GameObject[] objectPrefabs;
    public GameObject[] paths;
    
    private PathStrategy _waypointStrategy;
    private void Awake()
    {
        _waypointStrategy = new RandomPathStrategy(paths);
    }

    public GameObject GetObject(string type) {
        foreach (var prefab in objectPrefabs)
        {
            if (prefab.name == type)
            {
                GameObject newObject = Instantiate(prefab, transform.position, Quaternion.identity);
                newObject.GetComponent<FollowWaypoints>().waypoints = _waypointStrategy.GetWaypoints();
                newObject.name = type;
                return newObject;
            }
        }

        return null;
    }
}
