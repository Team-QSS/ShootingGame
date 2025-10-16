using UnityEngine;

public interface IStat<T>
{
    public T GetStat();
    public void SetStat(T stat);
}
