using UnityEngine;

[CreateAssetMenu(fileName = "FlightStatusSO", menuName = "Scriptable Objects/FlightStatusSO")]
//�÷��̾� ���� ��ũ���ͺ� ������Ʈ
public class FlightStatusSO : ScriptableObject
{
    //플레이어 hp
    public int maxLifePoints;
    //플레이어 공속
    public int attackSpeed;
    //플레이어 궁극기 스택
    public int maxUltStack; 

}
