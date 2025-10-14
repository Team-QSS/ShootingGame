using System;
using UnityEngine;

public class LimitedStat<T> : Stat<T> where T : IComparable<T>
{
    public event Action<T, T> onChanged;
    public T maxValue;
    public T minValue;

    public override void OnStatChanged(T val)
    {
        if (_value.CompareTo(val) != 0)
        {
            T newVal = val;

            if (val.CompareTo(maxValue) > 0)
            {
                newVal = maxValue;
            }
            if (val.CompareTo(minValue) < 0)
            {
                newVal = minValue;
            }
            _value = newVal; 
            onChanged?.Invoke(newVal, maxValue);
        }
    }

}
