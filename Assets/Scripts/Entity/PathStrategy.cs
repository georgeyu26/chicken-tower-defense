using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class PathStrategy
{
    private protected GameObject[] paths;
        
    public abstract Vector2[] GetWaypoints();

    private static IEnumerable<Vector2> EnumerateWaypoints(GameObject path)
    {
        foreach (Transform waypoint in path.transform) yield return waypoint.position;
    }

    private protected Vector2[] ExtractWaypointsFromPath(GameObject path)
    {
        return EnumerateWaypoints(path).ToArray();
    }
}