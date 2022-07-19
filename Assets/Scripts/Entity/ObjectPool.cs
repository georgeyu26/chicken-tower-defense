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
                switch (GameManager.Difficulty)
                {
                    case "Easy":
                        newObject.GetComponent<FollowWaypoints>().maxSpeed *= 0.75f;
                        break;
                    case "Medium":
                        newObject.GetComponent<FollowWaypoints>().maxSpeed *= 1.0f;
                        break;
                    case "Hard":
                        newObject.GetComponent<FollowWaypoints>().maxSpeed *= 1.25f;
                        break;
                }
                if (GameManager.RoundNumber > 50)
                {
                    newObject.GetComponent<FollowWaypoints>().maxSpeed += 0.5f * (GameManager.RoundNumber - 50f);
                    newObject.GetComponent<ChickenHealth>().maxHealth += 100 * (GameManager.RoundNumber - 50);
                }
                newObject.name = type;
                return newObject;
            }
        }

        return null;
    }
}
