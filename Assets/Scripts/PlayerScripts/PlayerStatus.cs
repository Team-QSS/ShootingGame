using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] private FlightStatus flightStatus;
    private LimitedStat<int> hp=new();
    private LimitedStat<int> ultgauge=new();
    private UnLimitedStat<float> attackSpeed = new();

    public void ResetStat()
    {
        hp.minValue = 0;
        hp.maxValue = flightStatus.maxLifePoints;
        hp.Value = hp.maxValue;
        ultgauge.minValue = 0;
        ultgauge.maxValue = flightStatus.maxUltStack;
        ultgauge.Value = 0;
        attackSpeed.Value = flightStatus.attackSpeed;
    }

    private void PrintStat()
    {
        Debug.Log(hp.Value);
        Debug.Log(ultgauge.Value);
        Debug.Log(attackSpeed.Value);
    }

    private void Start()
    {
        ResetStat();
        //PrintStat();
    }
}
