using System;
using UnityEngine;

//스탯 부모클래스
public class Stat<T> where T: IComparable<T>//비교 가능하게 하는 제너릭
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
    //스탯이 바뀔때 실행
    public virtual void OnStatChanged(T val){}
}
