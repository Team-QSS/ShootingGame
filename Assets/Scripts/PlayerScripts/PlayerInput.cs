using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    //해당 키를 누를때 실행할 이벤트들
    //이동시
    public event Action<Vector2> onMove;
    //회피/궁극기 사용 시
    public event Action onAvoid;
    //평타 시
    public event Action onFire;
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
