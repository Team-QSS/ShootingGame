using UnityEngine;

//플레이어의 입력과 이동 스크립트의 약한 결합을 위한 중계스크립트
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
