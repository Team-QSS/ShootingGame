using UnityEngine;

public interface IGetSetter<T>
{
    public T Get();
    public void Set(T value);
}
