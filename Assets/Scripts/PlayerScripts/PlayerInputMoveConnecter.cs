using UnityEngine;

public class PlayerInputMoveConnecter : MonoBehaviour,IConnecter
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private PlayerMove playerMove;
    public void Connect()
    {
        playerInput.onMove += playerMove.SetMove;
    }
    public void Disconnect()
    {
        playerInput.onMove -= playerMove.SetMove;
    }
    private void Start()
    {
        Connect();
    }
}
