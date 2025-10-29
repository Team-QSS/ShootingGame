using System;
using System.Collections.Generic;
using UnityEngine;

public enum EventKey
{
    //전투
    SpawnEnemy,
    //필드
    GetWayPointFromIndex,
    //카메라
    
    //UI
    ShowWavePanel
}

public class EventManager : SceneSingleMono<EventManager>
{
    private readonly Dictionary<EventKey, MulticastDelegate> _events = new();
    
    public void AddListener(EventKey actionKey, MulticastDelegate listener)
    {
        if (_events.TryGetValue(actionKey, out var existing))
        {
            if (existing.GetType() != listener.GetType())
            {
                throw new InvalidOperationException($"이벤트 [{actionKey}]는 {existing.GetType()} 형식만 받을 수 있음. 현재: {listener.GetType()}");
            }
            _events[actionKey] = (MulticastDelegate)MulticastDelegate.Combine(existing, listener);
        }
        else
        {
            _events[actionKey] = listener;
        }
    }
    
    public void RemoveListener(EventKey actionKey, MulticastDelegate listener)
    {
        if (_events.TryGetValue(actionKey, out var existing))
        {
            if (existing.GetType() != listener.GetType())
            {
                throw new InvalidOperationException($"이벤트 [{actionKey}] 구독 해제 시 형식 불일치. 기대: {existing.GetType()} / 현재: {listener.GetType()}");
            }

            var updated = existing;
            var invocationList = existing.GetInvocationList();
    
            foreach (var del in invocationList)
            {
                if (del.Method == listener.Method && 
                    ReferenceEquals(del.Target, listener.Target))
                {
                    updated = (MulticastDelegate)MulticastDelegate.Remove(updated, del);
                    break; 
                }
            }
    
            if (updated == null)
                _events.Remove(actionKey);
            else
                _events[actionKey] = updated;
        }
    }
    
    public T Invoke<T>(EventKey actionKey, params object[] args)
    {
        if (_events.TryGetValue(actionKey, out var del))
        {
            var result = del.DynamicInvoke(args);
            return result != null ? (T)result : default(T);
        }
        return default(T);
    }
    
    public void Invoke(EventKey actionKey, params object[] args)
    {
        if (_events.TryGetValue(actionKey, out var del))
        {
            del.DynamicInvoke(args);
        }
    }
}