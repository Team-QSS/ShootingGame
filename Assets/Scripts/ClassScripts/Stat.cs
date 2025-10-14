using System;
using UnityEngine;

//���� �θ�Ŭ����
public class Stat<T> where T: IComparable<T>//�� �����ϰ� �ϴ� ���ʸ�
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
    //������ �ٲ� ����
    public virtual void OnStatChanged(T val){}
}
