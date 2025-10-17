using UnityEngine;

public class PlayerStatus : MonoBehaviour,IStatusSetter
{
    [SerializeField] private FlightStatusSO flightStatus;
    public PlayerRuntimeStat playerRuntimeStat;

    public void ResetStat()
    {
        playerRuntimeStat.hp.minValue = 0;
        playerRuntimeStat.hp.maxValue = flightStatus.maxLifePoints;
        playerRuntimeStat.hp.Value = playerRuntimeStat.hp.maxValue;
        playerRuntimeStat.ultgauge.minValue = 0;
        playerRuntimeStat.ultgauge.maxValue = flightStatus.maxUltStack;
        playerRuntimeStat.ultgauge.Value = 0;
        playerRuntimeStat.attackSpeed.Value = flightStatus.attackSpeed;
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