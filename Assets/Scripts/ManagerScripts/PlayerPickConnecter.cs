using System;
using UnityEngine;

public class PlayerPickConnecter : MonoBehaviour,IConnecter
{
    [SerializeField] private int currentPlayers;
    [SerializeField] private PlayerPickUI[] playerPicks;
    [SerializeField] private FrameInputter[] playerInputs;
    [SerializeField] private FlightsGrid flightsGrid;

    private void Start()
    {
        Connect();
    }

    public void Connect()
    {
        flightsGrid.Initialize();
        for (var index = 0; index < playerPicks.Length; index++)
        {
            var t = playerPicks[index];
            var v = playerInputs[index];
            v.onMove += t.OnDirInput;
            v.onConfrim += t.Execute;
            v.onCancel += t.CancelExecute;
            t.onGet += flightsGrid.ReturnObj;
            t.onSendMove += flightsGrid.ReturnIndex;
            t.onExecute += MatchManager.Instance.OnReady;
            t.onCancel += MatchManager.Instance.OnLeave;

        }
    }
    public void Disconnect()
    {
        for (var index = 0; index < playerPicks.Length; index++)
        {
            var t = playerPicks[index];
            var v = playerInputs[index];
            playerInputs[index].onMove -= t.OnDirInput;
            v.onMove -= t.OnDirInput;
            v.onConfrim -= t.Execute;
            t.onGet -= flightsGrid.ReturnObj;
            t.onSendMove -= flightsGrid.ReturnIndex;
            t.onExecute -= MatchManager.Instance.OnReady;
            t.onCancel -= MatchManager.Instance.OnLeave;
        }
    }
    
}
