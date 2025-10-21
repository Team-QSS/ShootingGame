using System;
using UnityEngine;

public class PlayerStatus : MonoBehaviour,IStatusSetter
{
    [SerializeField] private FlightDataSO flightData;
    public PlayerRuntimeStat playerRuntimeStat;
    [SerializeField] private bool isInfinite;
    public event Action onInfinite;

    public void ResetStat()
    {
        playerRuntimeStat.hp.minValue = 0;
        playerRuntimeStat.hp.maxValue = flightData.maxLifePoints;
        playerRuntimeStat.hp.Value = playerRuntimeStat.hp.maxValue;
        playerRuntimeStat.ultgauge.minValue = 0;
        playerRuntimeStat.ultgauge.maxValue = flightData.maxUltStack;
        playerRuntimeStat.ultgauge.Value = 0;
        playerRuntimeStat.attackSpeed.Value = flightData.attackSpeed;
    }

    public GameObject SendToUseUlt()
    {
        if (playerRuntimeStat.ultgauge.Value == playerRuntimeStat.ultgauge.maxValue)
        {
            return flightData.skillEventPrefab;
        }
        return null;
    }

    public void SetInfinite(bool infinite)
    {
        if (infinite)
        {
            onInfinite?.Invoke();
        }
        isInfinite = infinite;
    }

    public bool GetInfinite()
    {
        return isInfinite;
    }

    private void PrintStat()
    {
        Debug.Log(playerRuntimeStat.hp.Value);
        Debug.Log(playerRuntimeStat.ultgauge.Value);
        Debug.Log(playerRuntimeStat.attackSpeed.Value);
    }

    private void Awake()
    {
        ResetStat();
    }
}