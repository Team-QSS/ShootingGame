using UnityEngine;

[CreateAssetMenu(fileName = "FlightStatus", menuName = "Scriptable Objects/FlightStatus")]
//�÷��̾� ���� ��ũ���ͺ� ������Ʈ
public class FlightStatus : ScriptableObject
{
    //�⺻ hp
    public int maxLifePoints;
    //�⺻ ����
    public int attackSpeed;
    //�⺻ �ñر� ����
    public int maxUltStack; 

}
