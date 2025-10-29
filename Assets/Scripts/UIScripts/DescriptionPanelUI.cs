using System;
using UnityEngine;
using TMPro;

public class DescriptionPanelUI : MonoBehaviour
{
    public void Start()
    {
        EventManager.Instance.AddListener(EventKey.ShowDescriptionPanel,new Action<bool>(SetActivePanel));
        EventManager.Instance.AddListener(EventKey.ActiveImageOnDescriptionPanel,new Action<int>(ActiveImage));
        EventManager.Instance.AddListener(EventKey.ChangeTextOnDescriptionPanel,new Action<string>(SetTexts));
        SetActivePanel(false);
    }
    
    public TextMeshProUGUI textComponent;
    public GameObject[] imageObjects;

    public void SetActivePanel(bool active)
    {
        if (!active)
        {
            GameTimeManager.Instance.StartClock();
        }
        gameObject.SetActive(active);
    }

    public void SetTexts(string text)
    {
        textComponent.text = text;
    }

    public void SetActiveAllImages(bool active)
    {
        for (int i = 0; i < imageObjects.Length; i++)
        {
            imageObjects[i].SetActive(active);
        }
    }

    public void ActiveImage(int i)
    {
        SetActiveAllImages(false);
        if (0 <= i && i < imageObjects.Length)
        {
            imageObjects[i].SetActive(true);
        }
    }

    public void ReplaceImage(int index, GameObject newPrefab)
    {
        if (index < 0 || index >= imageObjects.Length) return;

        Destroy(imageObjects[index]);
        GameObject newObj = Instantiate(newPrefab, transform);
        imageObjects[index] = newObj;
    }
}