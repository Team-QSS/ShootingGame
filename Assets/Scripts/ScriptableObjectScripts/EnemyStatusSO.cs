using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStatusSO", menuName = "Scriptable Objects/EnemyStatusSO")]
public class EnemyStatusSO : ScriptableObject
{
    public int maxLifePoints;
    public int bodyShotDamage;
    public float moveSpeed;
}
