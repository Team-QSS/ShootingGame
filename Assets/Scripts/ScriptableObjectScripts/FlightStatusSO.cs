using UnityEngine;

[CreateAssetMenu(fileName = "FlightDataSO", menuName = "Scriptable Objects/FlightDataSO")]
public class FlightDataSO : ScriptableObject
{
    //플레이어 hp
    public int maxLifePoints;
    //플레이어 공속
    public float attackSpeed;
    //플레이어 궁극기 스택
    public int maxUltStack;

    public GameObject skillEventPrefab;

}
