using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UtilScripts;

public class PlayerPickDataManager : SingleMono<PlayerPickDataManager>
{
    [ReadOnly] public FlightsDataArraySO flightsDataArraySO;
    [SerializeField] private List<FlightCode> players;
    private Dictionary<FlightCode, FlightsDataSO> flightCodeDict = new();
    
    
    
    public void Initalize()
    {
        var need = MatchManager.Instance.GetNeedPlayers();
        for (int i = 0; i <need; i++)
        {
            players.Add(FlightCode.Traveler);
        }

        for (int i = 0; i < flightsDataArraySO.flightData.Length; i++)
        {
            if (!flightCodeDict.ContainsKey(flightsDataArraySO.flightData[i].code))
            {
                flightCodeDict.Add(flightsDataArraySO.flightData[i].code, flightsDataArraySO.flightData[i]);
            }
        }
    }

    public void ChangePick(int index, FlightCode flightCode)
    {
        if (index >= 0 && index < players.Count && players[index] != flightCode)
        {
            players[index] = flightCode;
        }
    }

    public FlightCode GetCodeByIndex(int index)
    {
        return flightsDataArraySO.flightData[index].code;
    }

    public FlightsDataSO GetFlightDataByIndex(int index)
    {
        return flightCodeDict[players[index]];
    }
}
