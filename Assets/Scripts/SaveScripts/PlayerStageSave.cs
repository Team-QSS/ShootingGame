using System;
using UnityEngine;

[Serializable]
public class PlayerStageInfo : ISaveData
{
    public int limitStage;
    public string ToJson() => JsonUtility.ToJson(this);
    public void FromJson(string json) => JsonUtility.FromJsonOverwrite(json, this);
}

public class PlayerStageSave : MonoBehaviour,ISaveAble
{
    public PlayerStageInfo stage;
    public string GetSavePath()=> "PlayerStage";
    private SaveManager _saveManager;

    public void OnSave()
    {
        _saveManager.SaveData(GetSavePath(),stage);
    }

    public void OnLoad()
    {
        if (_saveManager.HasData(GetSavePath()))
        {
            stage.FromJson(_saveManager.LoadData(GetSavePath()));
        }
        else
        {
            stage.limitStage = 1;
            _saveManager.SaveData(GetSavePath(), stage);
        }
    }

    public void OnRemove()
    {
        _saveManager.RemoveData(GetSavePath());
    }

    void Start()
    {
        _saveManager = SaveManager.Instance;
        OnLoad();
    }
}
