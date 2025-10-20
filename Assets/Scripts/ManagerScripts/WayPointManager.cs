using System;
using UnityEngine;

public class WayPointManager : SceneSingleMono<WayPointManager>
{
    [SerializeField] private WayPointArraySO wayPointArraySO;
    public GameObject GetWayPointFromIdx(int idx)
    {
        if (idx >= 0 && idx < wayPointArraySO.wayPoints.Length)
        {
            return wayPointArraySO.wayPoints[idx].gameObject;
        }

        return null;
    }
}
