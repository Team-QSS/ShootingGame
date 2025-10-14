using System;
using UnityEngine;

public class Stat<T> where T: IComparable<T>
{
    protected T _value;
    public T Value
    {
        get=>_value;
        set
        {
            OnStatChanged(value);
        }
    }
    public virtual void OnStatChanged(T val){}
}
