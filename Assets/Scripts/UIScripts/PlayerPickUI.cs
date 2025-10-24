using System;
using UnityEngine;

public class PlayerPickUI : MonoBehaviour,IGetSetter<int>
{
    public event Func<int,GameObject> onGet;
    public event Func<Vector2,int,int> onSendMove;
    public event Action onExecute;
    public event Action onCancel;
    private bool _isPicked = false;
    
    private int _currentIndex;
    
    public int Get()=>_currentIndex;
    public void Set(int value)=>_currentIndex = value;

    public void SetPos(GameObject o)
    {
        gameObject.transform.position = o.transform.position;
    }

    public void OnDirInput(Vector2 dir)
    {
        if (!_isPicked)
        {
            _currentIndex = onSendMove?.Invoke(dir, _currentIndex) ?? _currentIndex;
            SetPos(onGet?.Invoke(_currentIndex));
        }
    }

    public void InitializePos(int index)
    {
        SetPos(onGet?.Invoke(index));
    }

    public void Execute()
    {
        if (!_isPicked)
        {
            onExecute?.Invoke();
            _isPicked = true;
        }
    }

    public void CancelExecute()
    {
        if (_isPicked)
        {
            onCancel?.Invoke();
            _isPicked = false;
        }
    }
    
}
