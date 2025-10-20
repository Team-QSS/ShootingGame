using System;
using Unity.VisualScripting;
using UnityEngine;

public class RaingerMinionBehaviour : MonoBehaviour,IBehaviorSetter
{
    public Fsm fsm;
    public WayPointArray wayPointArr;
    public EnemySkillCooldown enemyskillCooldown = new();
    [NonSerialized] public GameObject target;
    public event Action<Vector2> onMove;
    public event Action<float> onMoveSpeedChange;
    public IStat<EnemyRuntimeStat> iEnemyRuntimeStat;
    //public event Action
    public void Set()
    {
        var patrolUpDown = new RaingerMinionPatrolUpDown(this);
        var patrolLeftRight = new RaingerMinionPatrolLeftRight(this);
        fsm.RegisterState(EntityMoves.PatrolA,patrolUpDown);
        fsm.RegisterState(EntityMoves.PatrolB,patrolLeftRight);
        fsm.ChangeState(EntityMoves.PatrolA);
    }
    
//디버깅용
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            fsm.ChangeState(EntityMoves.PatrolB);
        }
    }
    
    

    public class RaingerMinionPatrolUpDown : IState
    {
        RaingerMinionBehaviour _behaviour;
        public RaingerMinionPatrolUpDown(RaingerMinionBehaviour fsm)
        {
            _behaviour = fsm;
        }
        public void Enter()
        {
            _behaviour.onMoveSpeedChange?.Invoke(_behaviour.iEnemyRuntimeStat.GetStat().moveSpeed*4);
            _behaviour.target=_behaviour.wayPointArr.GetWayPointTarget(_behaviour.wayPointArr.GetIndexModular(1));
        }

        public void Exit()
        {
            
        }

        public void Execute()
        {
            
        }

        public void FixedExecute()
        {
            var dir = _behaviour.target.transform.position - _behaviour.gameObject.transform.position;
            _behaviour.onMove?.Invoke(dir.normalized);
        }
    }
    public class RaingerMinionPatrolLeftRight : IState
    {
        RaingerMinionBehaviour _behaviour;
        public RaingerMinionPatrolLeftRight(RaingerMinionBehaviour fsm)
        {
            _behaviour = fsm;
        }
        public void Enter()
        {
            _behaviour.onMoveSpeedChange?.Invoke(_behaviour.iEnemyRuntimeStat.GetStat().moveSpeed*4);
            _behaviour.target=_behaviour.wayPointArr.GetWayPointTarget(_behaviour.wayPointArr.GetIndexModular(0));
        }

        public void Exit()
        {
            
        }

        public void Execute()
        {
            
        }

        public void FixedExecute()
        {
            var dir = _behaviour.target.transform.position - _behaviour.gameObject.transform.position;
            _behaviour.onMove?.Invoke(dir.normalized);
        }
    }
}
