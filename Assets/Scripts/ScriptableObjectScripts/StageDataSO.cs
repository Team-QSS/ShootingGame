using UnityEngine;

public enum StageCode
{
    HyperLoop,
    Tank,
    LavaCave,
    WatchersCastle,
    WarHall
}

[CreateAssetMenu(fileName = "StageDataSO", menuName = "Scriptable Objects/StageDataSO")]
public class StageDataSO : ScriptableObject
{
    public StageCode stageCode;
    [TextArea(3, 10)] public string stageName;
    public Sprite stageImage;
}
