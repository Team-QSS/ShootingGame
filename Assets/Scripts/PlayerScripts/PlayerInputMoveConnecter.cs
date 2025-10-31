using UnityEngine;
public class PlayerInputMoveConnecter : MonoBehaviour,IConnecter
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private PlayerMove playerMove;
    [SerializeField] private Bounding bounder;
    public void Connect()
    {
        playerInput.sendDir += playerMove.SetMove;
        playerInput.sendDir += bounder.Bound;
    }
    public void Disconnect()
    {
        playerInput.sendDir -= playerMove.SetMove;
    }
    private void Start()
    {
        Connect();
    }
}
