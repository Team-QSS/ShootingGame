using UnityEngine;

public enum EntityMoves
{
    Idle,
    PatrolA,
    PatrolB,
}

public abstract class EntityAnimator : MonoBehaviour
{
    public Animator ani;

    public virtual void SetAnimation(EntityMoves moves)
    {
        
    }
    public virtual void ChangeAnimation(string code)
    {
        
    }
}
