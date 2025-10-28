using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageDescriptionUI : MonoBehaviour
{
    [SerializeField] private TextMeshPro stageName;
    [SerializeField] private SpriteRenderer stageImage;
    
    public void UpdateUI()
    {
        stageName.transform.position = new Vector3(CameraManager.Instance.target.gameObject.transform.position.x, CameraManager.Instance.target.gameObject.transform.position.y-3.5f, 0);
        stageImage.transform.position = new Vector3(CameraManager.Instance.target.gameObject.transform.position.x, CameraManager.Instance.target.gameObject.transform.position.y+0.5f, 0);
        var data = StageDotManager.Instance.GetCurrentStageData();
        stageName.text = data.stageName;
        stageImage.sprite = data.stageImage;
    }
}
