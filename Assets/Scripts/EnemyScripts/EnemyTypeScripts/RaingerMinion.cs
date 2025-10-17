using UnityEngine;

public class RaingerMinion : AEnemy
{
    [SerializeField] private RaingerMinionBehaviour raingerMinionBehaviour;
    [SerializeField] private EnemyMove enemyMove;
    [SerializeField] private WayPointArray wayPointArray;
    private void Start()
    {
        Birth();
    }
    public override void Birth()
    {
        base.Birth();
        var istat = enemyStatus.gameObject.GetComponent<IStat<EnemyRuntimeStat>>();
        wayPointArray.SetMoveSpeed(enemyStatus.GetStat().moveSpeed);
        raingerMinionBehaviour.onMove+=enemyMove.SetMove;
        raingerMinionBehaviour.onMoveSpeedChange += enemyMove.SetSpeed;
        raingerMinionBehaviour.iEnemyRuntimeStat = istat;
        raingerMinionBehaviour.Set();
    }
}
