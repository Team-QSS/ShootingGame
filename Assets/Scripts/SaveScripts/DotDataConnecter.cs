using TMPro;
using UnityEngine;

public class DotDataConnecter : MonoBehaviour
{
    [SerializeField] private PlayerStageSave playerStageSave;
    
    void Start()
    {
        StageDotManager.Instance.Initialize(playerStageSave.stage.limitStage);
    }
}
