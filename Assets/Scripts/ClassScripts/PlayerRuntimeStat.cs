using UnityEngine;
[System.Serializable]
public class PlayerRuntimeStat
{
    public LimitedStat<int> hp=new();
    public LimitedStat<int> ultgauge=new();
    public UnLimitedStat<float> attackSpeed = new();
}
