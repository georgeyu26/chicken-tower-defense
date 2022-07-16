using System;
using System.Linq;
using UnityEngine;

public class ShortestPathStrategy : PathStrategy
{
    public ShortestPathStrategy(GameObject[] paths) { base.paths = paths; }

    public override Vector2[] GetWaypoints()
    {
        float[] pathLengths = new float[paths.Length];

        for (int i = 0; i < paths.Length; i++)
        {
            for (int j = 0; j < paths[i].transform.childCount; j++)
            {
                pathLengths[i] += (paths[i].transform.GetChild(j).transform.position - paths[i].transform.GetChild(j).transform.position).magnitude;
            }
        }

        return ExtractWaypointsFromPath(paths[Array.IndexOf(pathLengths, pathLengths.Min())]);
    }
}