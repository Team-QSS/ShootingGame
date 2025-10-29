using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public event Action<Vector2> onMove;
    public event Action onAvoid;
    public event Func<GameObject> onUseUlt;
    public void OnMove(InputAction.CallbackContext context)
    {
        //EventManager.Instance.Invoke(EventKey.ShowDescriptionPanel,false);
        var dir = context.ReadValue<Vector2>();
        onMove?.Invoke(dir);
    }
    public void OnAvoid(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            EventManager.Instance.Invoke(EventKey.ShowDescriptionPanel,false);
        }

    }
    public void OnUseUlt(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            EventManager.Instance.Invoke(EventKey.ShowDescriptionPanel,false);
            var obj = onUseUlt?.Invoke();
            if (obj != null)
            {
                ObjectPoolManager.Instance.Get(obj, Vector2.zero, Vector3.zero);
            }
            else
            {
                
            }
        }
    }
}
