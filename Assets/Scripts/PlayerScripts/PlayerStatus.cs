using UnityEngine;

public class PlayerStatus : MonoBehaviour,IStatusSetter
{
    [SerializeField] private FlightStatusSO flightStatus;
    private PlayerRuntimeStat _playerRuntimeStat;

    public void ResetStat()
    {
        _playerRuntimeStat.hp.minValue = 0;
        _playerRuntimeStat.hp.maxValue = flightStatus.maxLifePoints;
        _playerRuntimeStat.hp.Value = _playerRuntimeStat.hp.maxValue;
        _playerRuntimeStat.ultgauge.minValue = 0;
        _playerRuntimeStat.ultgauge.maxValue = flightStatus.maxUltStack;
        _playerRuntimeStat.ultgauge.Value = 0;
        _playerRuntimeStat.attackSpeed.Value = flightStatus.attackSpeed;
    }

    private void PrintStat()
    {
        Debug.Log(_playerRuntimeStat.hp.Value);
        Debug.Log(_playerRuntimeStat.ultgauge.Value);
        Debug.Log(_playerRuntimeStat.attackSpeed.Value);
    }

    private void Start()
    {
        ResetStat();
    }
}