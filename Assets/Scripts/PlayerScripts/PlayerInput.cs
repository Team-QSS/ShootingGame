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
            var obj = onUseUlt?.Invoke();
            if (obj != null)
            {
                ObjectPoolManager.Instance.Get(obj, Vector2.zero, Vector3.zero);
            }
            else
            {
                Debug.Log("게이지가 없거나 능력이 없습니다..");
            }
        }
    }
}
