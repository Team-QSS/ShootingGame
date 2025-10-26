using System;
using UnityEngine;

public enum FlightCode
{
    Traveler,
    ChainSaw,
    Guardian,
    Solid,
    Gunner
}
public class FrameUI : MonoBehaviour,IGetSetter<FlightsDataSO>
{
    [SerializeField] FlightsDataSO flightCode;
    
    public FlightsDataSO Get()=>flightCode;

    public void Set(FlightsDataSO o)
    {
        flightCode = o;
    }
}
