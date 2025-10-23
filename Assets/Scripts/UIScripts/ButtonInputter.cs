using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonInputter : MonoBehaviour
{
    public event Action<int> onMove;
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
}
