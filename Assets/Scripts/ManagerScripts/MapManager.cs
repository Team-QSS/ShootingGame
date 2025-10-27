using System.Collections.Generic;
using UnityEngine;
using UtilScripts;

public class MapManager : SingleMono<MapManager>
{
    [SerializeField] private StageDataArraySO stageDataArray;
    [SerializeField] private int currentIndex;
    
    private Dictionary<StageCode, int> stageDataDictionary = new();

    public void Start()
    {
        for(int s = 0; s<stageDataArray.stageDataArray.Length; s++)
        {
            if (!stageDataDictionary.ContainsKey(stageDataArray.stageDataArray[s].stageCode))
            {
                stageDataDictionary.Add(stageDataArray.stageDataArray[s].stageCode,s);
            }
        }
    }
    
    public StageDataSO GetStageData(int index)
    {
        return MapManager.Instance.stageDataArray.stageDataArray[index];
    }

    public void SetCurrentStageByIndex(int index)
    {
        currentIndex = index;
    }

    public void SetCurrentStageByCode(StageCode code)
    {
        stageDataDictionary[code] = currentIndex;
    }
    
}
