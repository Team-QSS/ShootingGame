using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class FrameInputter : MonoBehaviour,
{
    public event Action<int> onMove;
    public event Action onConfrim;
    public event Action onCancel;
    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            var val = context.ReadValue<Vector2>();
            if(val.y >0)
            {
                onMove?.Invoke(-1);
            }
            else if(val.y < 0)
            {
                onMove?.Invoke(1);
            }
        }

    }
    public void OnConfirm(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            onConfrim?.Invoke();
        }

    }
    public void OnCancel(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("cancel");
        }
    }
}
