using UnityEngine;

[CreateAssetMenu(fileName = "FlightsDataArraySO", menuName = "Scriptable Objects/FlightsDataArraySO")]
public class FlightsDataArraySO : ScriptableObject
{
    public FlightsDataSO[] flightData;
}
