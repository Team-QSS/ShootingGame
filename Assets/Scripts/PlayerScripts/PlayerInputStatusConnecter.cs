using System;
using UnityEngine;

public class PlayerInputStatusConnecter : MonoBehaviour,IConnecter
{
    [SerializeField] PlayerInput playerInput;
    [SerializeField] PlayerStatus playerStatus;

    public void Start()
    {
        Connect();
    }

    public void Connect()
    {
        playerInput.onUseUlt += playerStatus.SendToUseUlt;
    }

    public void Disconnect()
    {
        playerInput.onUseUlt -= playerStatus.SendToUseUlt;
    }
}
