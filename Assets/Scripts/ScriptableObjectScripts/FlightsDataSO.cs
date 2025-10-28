using UnityEngine;

[CreateAssetMenu(fileName = "FlightsDataSO", menuName = "Scriptable Objects/FlightsDataSO")]
public class FlightsDataSO : ScriptableObject
{
    public FlightCode code;
    public string flightName;
    public Sprite flightSprite;
    [TextArea]
    public string flightDescription;
    public FlightDataSO flightDataSO;
}
