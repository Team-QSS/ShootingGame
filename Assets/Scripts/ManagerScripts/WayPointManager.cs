using System;
using UnityEngine;

public class WayPointManager : SceneSingleMono<WayPointManager>,IEvent
{
    [SerializeField] private WayPointArraySO wayPointArraySO;

    private void Start()
    {
        Subscribe();
    }
    public GameObject GetWayPointFromIdx(int idx)
    {
        if (idx >= 0 && idx < wayPointArraySO.wayPoints.Length)
        {
            return wayPointArraySO.wayPoints[idx].gameObject;
        }

        return null;
    }

    public void Subscribe()
    {
        EventManager.Instance.AddListener(EventKey.GetWayPointFromIndex,new Func<int,GameObject>(GetWayPointFromIdx));
    }

    public void Unsubscribe()
    {
        EventManager.Instance.RemoveListener(EventKey.GetWayPointFromIndex,new Func<int,GameObject>(GetWayPointFromIdx));
    }
}
