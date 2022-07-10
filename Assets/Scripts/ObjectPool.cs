using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {
    public GameObject[] objectPrefabs;
    public GameObject[] waypoints;
    public GameObject GetObject(string type) {
        for (int i = 0; i < objectPrefabs.Length; i++) {
            if (objectPrefabs[i].name == type) {
                GameObject newObject = Instantiate(objectPrefabs[i], transform.position, Quaternion.identity);
                newObject.GetComponent<FollowWaypoints>().waypoints = waypoints;
                newObject.name = type;
                return newObject;
            }
        }
        return null;
    }
}
