using UnityEngine;

[CreateAssetMenu(fileName = "StageDataArraySO", menuName = "Scriptable Objects/StageDataArraySO")]
public class StageDataArraySO : ScriptableObject
{
    public StageDataSO[] stageDataArray;
}
