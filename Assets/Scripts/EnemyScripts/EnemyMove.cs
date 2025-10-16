using System;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private float _speed;
    private IStat<EnemyRuntimeStat> _iEnemyStat;

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }
    public void SetMove(Vector2 dir)
    {
        rb.linearVelocity = dir*_speed;
    }
}
