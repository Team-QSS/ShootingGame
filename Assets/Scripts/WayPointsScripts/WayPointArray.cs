using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WayPointArray : MonoBehaviour
{
    [SerializeField] private List<WayPoints> wayPoints;
    private GameObject _currentWayPoint;
    private int _currentIndex = -1;

    public void AddWayPoint(WayPoints wp)
    {
        wayPoints.Add(wp);
    }

    public void RemoveWayPoint(WayPoints wp)
    {
        int index = wayPoints.IndexOf(wp);
        if (index >= 0)
        {
            wayPoints.RemoveAt(index);
        }
    }

    public GameObject GetWayPointTarget(int index)
    {
        if (index < 0 || index >= wayPoints.Count)
        {
            return null;
        }

        ObjectPoolManager poolManager = ObjectPoolManager.Instance;
        
        if (_currentWayPoint != null && _currentIndex != index)
        {
            poolManager.Return(_currentWayPoint);
        }

        _currentIndex = index;
        _currentWayPoint = poolManager.Get(wayPoints[index].gameObject, Vector2.zero, Vector2.zero);
        
        return _currentWayPoint.GetComponent<WayPoints>().target;
    }

    public void SetAllSplines(float speed)
    {
        foreach (WayPoints wp in wayPoints)
        {
            wp.SetSpline(speed);
        }
    }
}