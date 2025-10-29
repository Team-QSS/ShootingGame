using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class MapEvent
{
    public int timeLine;
    public List<EventKey> eventTypes;
}

[CreateAssetMenu(fileName = "MapTimeTableSO", menuName = "Scriptable Objects/MapTimeTableSO")]
public class MapTimeTableSO : ScriptableObject
{
    public MapEvent[] set;
}
