using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class FrameInputter : MonoBehaviour
{
    public event Action<Vector2> onMove;
    public event Action onConfrim;
    public event Action onCancel;
    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            var val = context.ReadValue<Vector2>();
            onMove?.Invoke(val);
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
            onCancel?.Invoke();
        }
    }
}
