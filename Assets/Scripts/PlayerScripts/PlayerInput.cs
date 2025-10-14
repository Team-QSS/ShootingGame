using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public event Action<Vector2> onMove;
    public event Action onAvoid;
    public event Action onUseUlt;
    public void OnMove(InputAction.CallbackContext context)
    {
        var dir = context.ReadValue<Vector2>();
        onMove?.Invoke(dir);
        //Debug.Log(dir);
    }
    public void OnAvoid(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            //Debug.Log("Avoid");
        }

    }
    public void OnUseUlt(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            //Debug.Log("Ult!!");
        }
    }
}
