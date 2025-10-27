using UnityEngine;

public class DotInputConnecter : MonoBehaviour,IConnecter
{
    [SerializeField] private ButtonInputter[] buttonInputters;
    [SerializeField] private StageDescriptionUI stageDescriptionUI;

    private void Start()
    {
        Connect();
        StageDotManager.Instance.SetFrame(0);
    }
    
    public void Connect()
    {
        StageDotManager.Instance.onMove+=stageDescriptionUI.UpdateUI;
        StageDotManager.Instance.onOver += CameraManager.Instance.ShakeCamera;
        for (int i = 0; i < buttonInputters.Length; i++)
        {
            buttonInputters[i].onMove += StageDotManager.Instance.MoveFrame;
        }
    }

    public void Disconnect()
    {
        StageDotManager.Instance.onMove-=stageDescriptionUI.UpdateUI;
        StageDotManager.Instance.onOver -= CameraManager.Instance.ShakeCamera;
        for (int i = 0; i < buttonInputters.Length; i++)
        {
            buttonInputters[i].onMove -= StageDotManager.Instance.MoveFrame;
        }
    }
}
