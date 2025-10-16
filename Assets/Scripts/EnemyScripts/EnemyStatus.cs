using UnityEngine;

public class EnemyStatus : MonoBehaviour,IStatusSetter,IStat<EnemyRuntimeStat>
{
    [SerializeField] private EnemyStatusSO enemyStatus;
    private EnemyRuntimeStat _enemyRuntimeStat = new EnemyRuntimeStat();

    public void ResetStat()
    {
        _enemyRuntimeStat.hp.minValue = 0;
        _enemyRuntimeStat.hp.maxValue = enemyStatus.maxLifePoints;
        _enemyRuntimeStat.hp.Value = _enemyRuntimeStat.hp.maxValue;
        _enemyRuntimeStat.moveSpeed = enemyStatus.moveSpeed;
        _enemyRuntimeStat.bodyShotDamage = enemyStatus.bodyShotDamage;
    }

    public EnemyRuntimeStat GetStat()
    {
        return _enemyRuntimeStat;
    }

    public void SetStat(EnemyRuntimeStat stat)
    {
        _enemyRuntimeStat = stat;
    }
}
