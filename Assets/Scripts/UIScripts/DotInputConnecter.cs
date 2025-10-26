using UnityEngine;

public class DotInputConnecter : MonoBehaviour,IConnecter
{
    [SerializeField] private ButtonInputter[] buttonInputters;

    private void Start()
    {
        Connect();
    }
    
    public void Connect()
    {
        for (int i = 0; i < buttonInputters.Length; i++)
        {
            buttonInputters[i].onMove += StageDotManager.Instance.MoveFrame;
        }
    }

    public void Disconnect()
    {
        for (int i = 0; i < buttonInputters.Length; i++)
        {
            buttonInputters[i].onMove -= StageDotManager.Instance.MoveFrame;
        }
    }
}
