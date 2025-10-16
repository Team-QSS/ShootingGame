using UnityEngine;

public abstract class AEnemy : MonoBehaviour,IPoolingObject
{
    [SerializeField] protected EnemyStatus enemyStatus;
    
    public virtual void Birth()
    {
        enemyStatus.ResetStat();
    }
    public virtual void Death(){}

    public void OnBirth()
    {
        Birth();
    }

    public void OnDeathInit()
    {
        Death();
    }
}
