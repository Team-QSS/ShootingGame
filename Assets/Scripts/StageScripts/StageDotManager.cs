using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UtilScripts;

public class StageDotManager : SceneSingleMono<StageDotManager>
{
    [SerializeField] private GameObject dotPrefab;
    [SerializeField] private GameObject frameDot;
    [SerializeField] private List<GameObject> dots;
    [SerializeField] private float dotDistance;
    [SerializeField] private int currentIndex;

    private int numDots;

    public event Action onMove;
    public event Action<float,float> onOver;

    public void Initialize(int count)
    {
        numDots = count;
        for (int i = 0; i < numDots; i++)
        {
            dots.Add(Instantiate(dotPrefab, new Vector2(i*dotDistance,0), Quaternion.identity));
        }
    }

    public void SetFrame(int index)
    {
        var origin = currentIndex;
        currentIndex = index;
        if (currentIndex < 0 || currentIndex >= numDots)
        {
            onOver?.Invoke(0.4f,0.1f);
            currentIndex = origin;
        }
        frameDot.gameObject.transform.position = dots[currentIndex].transform.position;
        CameraManager.Instance.SetTarget(dots[currentIndex].transform.GetChild(0).transform);
        onMove?.Invoke();
    }

    public void MoveFrame(int dir)
    {
        var origin = currentIndex;
        if (dir > 0)
        {
            currentIndex--;
        }
        else if (dir < 0)
        {
            currentIndex++;
        }

        if (currentIndex < 0 || currentIndex >= numDots)
        {
            onOver?.Invoke(0.4f,0.1f);
            currentIndex = origin;
        }
        frameDot.gameObject.transform.position = dots[currentIndex].transform.position;
        CameraManager.Instance.SetTarget(dots[currentIndex].transform.GetChild(0).transform);
        MapManager.Instance.SetCurrentStageByIndex(currentIndex);
        onMove?.Invoke();
    }
    public StageDataSO GetCurrentStageData()
    {
        return MapManager.Instance.GetStageData(currentIndex);
    }
    
    
}
