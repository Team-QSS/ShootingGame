using UnityEngine;

[CreateAssetMenu(fileName = "FlightStatus", menuName = "Scriptable Objects/FlightStatus")]
public class FlightStatus : ScriptableObject
{
    public int maxLifePoints;
    public int attackSpeed;
    public int maxUltStack;

}
