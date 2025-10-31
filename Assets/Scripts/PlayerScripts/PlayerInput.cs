using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum PlayerInputType
{
    Move,
    Ultimate,
    Settings
}

public class PlayerInput : MonoBehaviour
{
    public event Action<Vector2> sendDir;
    public event Action onAvoid;
    public event Func<GameObject> onUseUlt;

    [SerializeField]private PlayerInputType _currentKeyBindTutorial;

    private void Start()
    {
        EventManager.Instance.AddListener(EventKey.ChangeKeyBindEvents,new Action<PlayerInputType>(ChangeCurrentKeyBind));
        _currentKeyBindTutorial = PlayerInputType.Settings;
    }
    
    public void OnMove(InputAction.CallbackContext context)
    {
        if (_currentKeyBindTutorial == PlayerInputType.Move)
        {
            EventManager.Instance?.Invoke(EventKey.ShowDescriptionPanel,false);
        }
        var dir = context.ReadValue<Vector2>();
        sendDir?.Invoke(dir);
    }
    public void OnAvoid(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (_currentKeyBindTutorial == PlayerInputType.Ultimate)
            {
                EventManager.Instance?.Invoke(EventKey.ShowDescriptionPanel,false);
            }
        }

    }
    public void OnUseUlt(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (_currentKeyBindTutorial == PlayerInputType.Settings)
            {
                EventManager.Instance?.Invoke(EventKey.ShowDescriptionPanel,false);
            }
            var obj = onUseUlt?.Invoke();
            if (obj != null)
            {
                ObjectPoolManager.Instance.Get(obj, Vector2.zero, Vector3.zero);
            }
        }
    }

    public void ChangeCurrentKeyBind(PlayerInputType newKeyBind)
    {
        if (_currentKeyBindTutorial != newKeyBind)
        {
            _currentKeyBindTutorial = newKeyBind;
        }
    }
    
}
