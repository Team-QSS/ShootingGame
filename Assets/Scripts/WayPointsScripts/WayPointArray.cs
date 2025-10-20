using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WayPointArray : MonoBehaviour
{
    //[SerializeField] private List<WayPoints> wayPoints;
    [SerializeField] private List<int> wayPointIndexSet = new();
    private GameObject _currentWayPoint;
    private int _currentIndex = -1;
    private float _moveSpeed;

    public void AddWayPointIndex(int index)
    {
        if (!wayPointIndexSet.Contains(index))
        {
            wayPointIndexSet.Add(index);
        }
    }

    public void RemoveWayPointIndex(int index)
    {
        if (wayPointIndexSet.Contains(index))
        {
            wayPointIndexSet.Remove(index);
        }
    }

    public GameObject GetWayPointTarget(int index)
    {
        if (index < 0 || index >= wayPointIndexSet.Count)
        {
            return null;
        }

        ObjectPoolManager poolManager = ObjectPoolManager.Instance;
        
        if (_currentWayPoint != null && _currentIndex != index)
        {
            poolManager.Return(_currentWayPoint);
        }

        _currentIndex = index;
        _currentWayPoint = poolManager.Get(WayPointManager.Instance.GetWayPointFromIdx(index), Vector2.zero, Vector2.zero);
        Debug.Log(_currentWayPoint);
        var wayPoint = _currentWayPoint.GetComponent<WayPoints>();
        wayPoint.SetSpline(_moveSpeed);
        return wayPoint.target;
    }

    public void SetMoveSpeed(float moveSpeed)
    {
        _moveSpeed = moveSpeed;
    }

    public int GetIndexModular(int index)
    {
        return wayPointIndexSet[index%wayPointIndexSet.Count];
    }

    public bool IsIndexAble(int index)
    {
        return index >= 0 && index < wayPointIndexSet.Count;
    }
}