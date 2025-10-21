using UnityEngine;
public class PlayerInputMoveConnecter : MonoBehaviour,IConnecter
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private PlayerMove playerMove;
    [SerializeField] private Bounding bounder;
    public void Connect()
    {
        playerInput.onMove += playerMove.SetMove;
        playerInput.onMove += bounder.Bound;
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
