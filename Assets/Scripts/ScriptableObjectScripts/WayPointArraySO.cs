using UnityEngine;

[CreateAssetMenu(fileName = "WayPointArraySO", menuName = "Scriptable Objects/WayPointArraySO")]
public class WayPointArraySO : ScriptableObject
{
    public WayPoints[] wayPoints;
}
