using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UtilScripts;

public class MatchManager : SceneSingleMono<MatchManager>
{
    [SerializeField] private TextMeshProUGUI tmp;
    [SerializeField] private int needPlayers;
    [SerializeField] private int currentPlayers;
    private string _inGameSceneHash = "MapPanel";

    public void OnReady()
    {
        currentPlayers++;
        if (currentPlayers == needPlayers)
        {
            SceneManager.LoadScene(_inGameSceneHash);
        }
        tmp.text = currentPlayers+"/"+needPlayers;
    }

    public void OnLeave()
    {
        currentPlayers--;
        if (currentPlayers == 0)
        {
            tmp.text = "우주선을 골라주세요";
        }
        else
        {
            tmp.text = currentPlayers+"/"+needPlayers;
        }
    }

    public int GetNeedPlayers()
    {
        return needPlayers;
    }
    
}
