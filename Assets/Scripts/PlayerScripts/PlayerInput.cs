using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public void OnMove(InputAction.CallbackContext context)
    {
        var dir = context.ReadValue<Vector2>();
        Debug.Log(dir);
    }
    public void OnAvoid(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("Avoid");
        }

    }
    public void OnUseUlt(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("Ult!!");
        }
    }
}
