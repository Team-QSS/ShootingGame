using System;
using UnityEngine;

namespace UIScripts
{
    public class PlayerUIConnector : MonoBehaviour, IConnecter
    {
        [SerializeField] private PlayerStatus playerStatus;
        [SerializeField] private BarUI hpBarUI;
        [SerializeField] private BarUI ultimateBarUI;
        
        private void Start()
        {
            Connect();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerStatus.playerRuntimeStat.hp.Value--;
            }
        }

        public void Connect()
        {
            playerStatus.playerRuntimeStat.hp.onChanged += hpBarUI.OnDrawBar;
            playerStatus.playerRuntimeStat.ultgauge.onChanged += ultimateBarUI.OnDrawBar;
        }

        public void Disconnect()
        {
            playerStatus.playerRuntimeStat.hp.onChanged -= hpBarUI.OnDrawBar;
            playerStatus.playerRuntimeStat.ultgauge.onChanged -= ultimateBarUI.OnDrawBar;
        }
    }
}
