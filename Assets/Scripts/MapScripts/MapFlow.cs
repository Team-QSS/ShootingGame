using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapFlow : MonoBehaviour
{
    public MapTimeTableSO timeTable;
    protected Dictionary<int,List<EventKey>> eventTable = new();
    protected List<int> timeList = new();

    private void Start()
    {
        GameTimeManager.Instance.onClock += CheckTime;
        Initialize();
    }
    
    

    public virtual void Initialize()
    {
        foreach (var t in timeTable.set)
        {
            if (!eventTable.ContainsKey(t.timeLine))
            {
                eventTable.Add(t.timeLine,t.eventTypes);
            }
        }

        foreach (var e in timeList)
        {
            if (!timeList.Contains(e))
            {
                timeList.Add(e);
            }
        }
        timeList.Sort();
    }

    public void CheckTime(float time)
    {
        Debug.Log("CheckTime " + time);
        while (timeList.Count>0 &&time >= timeList[0])
        {

            Execute(timeList[0]);
            timeList.RemoveAt(0);
        }
    }

    public void Execute(int key)
    {
        foreach (var e in eventTable[key])
        {
            EventManager.Instance.Invoke(e);
        }
    }
    

}
