using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class MapFlow : MonoBehaviour
{
    public MapTimeTableSO timeTable;
    protected Dictionary<int,Action> eventTable = new();
    protected List<int> timeList = new();

    private void Start()
    {
        GameTimeManager.Instance.onClock += CheckTime;
        Initialize();
    }
    
    

    public virtual void Initialize()
    {
        timeList.Clear();
    
        foreach (var t in timeTable.set)
        {
            if (!timeList.Contains(t))
            {
                timeList.Add(t);
            }
            
            if (!eventTable.ContainsKey(t))
            {
                eventTable[t] = () => { }; 
            }
        }
        timeList.Sort();
        eventTable[CheckIndex(1)] += OnGameStartPanel;
    }



    public int CheckIndex(int num)
    {
        if (timeList.Contains(num))
        {
            return num;
        }
        return 0;
    }
    
    public void CheckTime(float time)
    {
        while (timeList.Count>0 &&time >= timeList[0])
        {
            Execute(timeList[0]);
            timeList.RemoveAt(0);
        }
    }

    public void Execute(int key)
    {
        eventTable[key]?.Invoke();
    }

    public void OnGameStartPanel()
    {
        EventManager.Instance.Invoke(EventKey.ShowWavePanel,"게임 시작");
    }
    

}
