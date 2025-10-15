using UnityEngine;

[CreateAssetMenu(fileName = "FlightStatus", menuName = "Scriptable Objects/FlightStatus")]
//�÷��̾� ���� ��ũ���ͺ� ������Ʈ
public class FlightStatus : ScriptableObject
{
    //플레이어 hp
    public int maxLifePoints;
    //플레이어 공속
    public int attackSpeed;
    //플레이어 궁극기 스택
    public int maxUltStack; 

}
