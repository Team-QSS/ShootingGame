using System;
using UnityEngine;
[System.Serializable]
public class EnemyRuntimeStat
{
    public LimitedStat<int> hp=new();
    public float moveSpeed;
    public int bodyShotDamage;
}
