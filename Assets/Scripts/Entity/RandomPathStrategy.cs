using UnityEngine;
using Random = System.Random;

public class RandomPathStrategy : PathStrategy
{
    public RandomPathStrategy(GameObject[] paths) { base.paths = paths; }

    public override Vector2[] GetWaypoints()
    {
        return ExtractWaypointsFromPath(paths[new Random().Next(paths.Length)]);
    }
}