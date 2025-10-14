using UnityEngine;

[CreateAssetMenu(fileName = "FlightStatus", menuName = "Scriptable Objects/FlightStatus")]
//플레이어 스탯 스크립터블 오브젝트
public class FlightStatus : ScriptableObject
{
    //기본 hp
    public int maxLifePoints;
    //기본 공속
    public int attackSpeed;
    //기본 궁극기 스탯
    public int maxUltStack; 

}
