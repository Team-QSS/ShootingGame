using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageDotManager : SceneSingleMono<StageDotManager>
{
    [SerializeField] private GameObject dotPrefab;
    [SerializeField] private GameObject frameDot;
    [SerializeField] private List<GameObject> dots;
    [SerializeField] private StageDataArraySO stageDataArray;
    [SerializeField] private int numDots;
    [SerializeField] private float dotDistance;
    [SerializeField] private int currentIndex;
    [SerializeField] private TextMeshProUGUI dotCountText;

    private void Start()
    {
        for (int i = 0; i < numDots; i++)
        {
            dots.Add(Instantiate(dotPrefab, new Vector2(i*dotDistance,0), Quaternion.identity));
        }
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
            currentIndex = origin;
        }
        frameDot.gameObject.transform.position = dots[currentIndex].transform.position;
        CameraManager.Instance.SetTarget(dots[currentIndex].transform.GetChild(0).transform);
        dotCountText.text = stageDataArray.stageDataArray[currentIndex].stageName;
    }
    
}
