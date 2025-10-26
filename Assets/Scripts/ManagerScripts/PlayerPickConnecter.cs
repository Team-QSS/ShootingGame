using System;
using UnityEngine;

[Serializable]
public class FlightFrameObject
{
    public PlayerPickUI playerPick;
    public FrameInputter frameInputter;
    public PickDescriptionUI descriptionUI;
}

public class PlayerPickConnecter : MonoBehaviour,IConnecter
{
    [SerializeField] private int currentPlayers;
    [SerializeField] private FlightFrameObject[] flightFrameObjects;
    [SerializeField] private FlightsGrid flightsGrid;

    private void Start()
    {
        Connect();
        for (var index = 0; index < flightFrameObjects.Length; index++)
        {
            var c =  flightFrameObjects[index].descriptionUI;
            c.OnUpdateUI();
        }
    }

    public void Connect()
    {
        flightsGrid.Initialize();
        for (var index = 0; index < flightFrameObjects.Length; index++)
        {
            var t = flightFrameObjects[index].playerPick;
            var v = flightFrameObjects[index].frameInputter;
            var c =  flightFrameObjects[index].descriptionUI;
            v.onMove += t.OnDirInput;
            v.onConfrim += t.Execute;
            v.onCancel += t.CancelExecute;
            t.onGet += flightsGrid.ReturnObj;
            t.onSendMove += flightsGrid.ReturnIndex;
            t.onExecute += MatchManager.Instance.OnReady;
            c.getIndex += t.Get;
            c.getFlightsData += flightsGrid.ReturnFlightData;
            v.onMoveSet += c.OnUpdateUI;
            t.onCancel += MatchManager.Instance.OnLeave;
        }
    }
    public void Disconnect()
    {
        for (var index = 0; index < flightFrameObjects.Length; index++)
        {
            var t = flightFrameObjects[index].playerPick;
            var v = flightFrameObjects[index].frameInputter;
            var c =  flightFrameObjects[index].descriptionUI;
            flightFrameObjects[index].frameInputter.onMove -= t.OnDirInput;
            v.onMove -= t.OnDirInput;
            v.onConfrim -= t.Execute;
            t.onGet -= flightsGrid.ReturnObj;
            t.onSendMove -= flightsGrid.ReturnIndex;
            t.onExecute -= MatchManager.Instance.OnReady;
            t.onCancel -= MatchManager.Instance.OnLeave;
            c.getIndex -= t.Get;
            c.getFlightsData -= flightsGrid.ReturnFlightData;
            v.onMoveSet -= c.OnUpdateUI;
        }
    }
    
}
