using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: this is template code, behaviour was moved to GameManager
public class SpawnEntity : MonoBehaviour
{
    public float spawnRate;
    public GameObject spawnable;

    private float _timeToSpawn;
    
    // This should be in a child factory that inherits from this, not in this class itself.
    public GameObject[] waypoints;
    
    private void Update()
    {
        // if (_timeToSpawn <= 0)
        // {
        //     AfterInstantiation(Instantiate(spawnable, transform.position, Quaternion.identity));

        //     _timeToSpawn = spawnRate;
        // }
        // else
        // {
        //     _timeToSpawn -= Time.deltaTime;
        // }
    }

    // When we start abstracting things after the demo, this SpawnEntity will become a generic factory that
    // other classes can inherit from, so the following function will become an interface in this class
    // and classes that inherit from it will implement it. _FOR NOW_, we hardcode this spawner to be for chickens only.
    private void AfterInstantiation(GameObject spawned)
    {
        spawned.GetComponent<FollowWaypoints>().waypoints = waypoints;
    }
}
