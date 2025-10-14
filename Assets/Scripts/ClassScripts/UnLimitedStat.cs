using System;
using UnityEngine;

public class UnLimitedStat<T> : Stat<T> where T : IComparable<T>
{
    public event Action<T> onChanged;

    public override void OnStatChanged(T val)
    {
        if (_value.CompareTo(val) != 0)
        {
            _value = val; 
            onChanged?.Invoke(val);
        }
    }

}
