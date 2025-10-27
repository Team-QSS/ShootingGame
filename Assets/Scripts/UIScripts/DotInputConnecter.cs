using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class DotInputConnecter : MonoBehaviour,IConnecter
{
    [SerializeField] private ButtonInputter[] buttonInputters;
    [SerializeField] private StageDescriptionUI stageDescriptionUI;
    [SerializeField] private ScreenFadeInner screenFadeInner;
    [SerializeField] private PlayerStageSave playerStageSave;

    private void Start()
    {
        Connect();
        StageDotManager.Instance.Initialize(playerStageSave.stage.limitStage);
        StageDotManager.Instance.SetFrame(0);
    }
    
    public void Connect()
    {
        StageDotManager.Instance.onMove+=stageDescriptionUI.UpdateUI;
        StageDotManager.Instance.onOver += CameraManager.Instance.ShakeCamera;
        for (int i = 0; i < buttonInputters.Length; i++)
        {
            buttonInputters[i].onMove += StageDotManager.Instance.MoveFrame;
            buttonInputters[i].onConfrim += screenFadeInner.Fade;
        }
    }

    public void Disconnect()
    {
        StageDotManager.Instance.onMove-=stageDescriptionUI.UpdateUI;
        StageDotManager.Instance.onOver -= CameraManager.Instance.ShakeCamera;
        for (int i = 0; i < buttonInputters.Length; i++)
        {
            buttonInputters[i].onMove -= StageDotManager.Instance.MoveFrame;
            buttonInputters[i].onConfrim -= screenFadeInner.Fade;
        }
    }
}
