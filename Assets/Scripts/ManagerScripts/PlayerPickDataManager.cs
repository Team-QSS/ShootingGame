using System.Collections.Generic;
using UnityEngine;
using UtilScripts;

public class PlayerPickDataManager : SingleMono<PlayerPickDataManager>
{
    [SerializeField] private List<FlightCode> players;

    public void Initalize()
    {
        var need = MatchManager.Instance.GetNeedPlayers();
        for (int i = 0; i <need; i++)
        {
            players.Add(FlightCode.Traveler);
        }
    }

    public void ChangePick(int index, FlightCode flightCode)
    {
        if (index >= 0 && index < players.Count && players[index] != flightCode)
        {
            players[index] = flightCode;
        }
    }
}
