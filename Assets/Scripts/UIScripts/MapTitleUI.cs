using System;
using TMPro;
using UnityEngine;

public class MapTitleUI : MonoBehaviour,IEvent
{
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private Animator ani;
    private readonly string showTrigger = "Intro";
    
    public void ShowTitle(string title)
    {
        titleText.text = title;
        ani.SetTrigger(showTrigger);
    }
    
    public void SetTitle(string newTitle)
    {
        titleText.text = newTitle;
    }

    public void Subscribe()
    {
        EventManager.Instance.AddListener(EventKey.ShowWavePanel,new Action<string>(ShowTitle));
    }

    public void Unsubscribe()
    {
        EventManager.Instance.RemoveListener(EventKey.ShowWavePanel,new Action<string>(ShowTitle));
    }

    private void Start()
    {
        Subscribe();
    }
}