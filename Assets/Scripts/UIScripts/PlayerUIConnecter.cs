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

        public void Connect()
        {
            hpBarUI.slider.maxValue = playerStatus.playerRuntimeStat.hp.maxValue;
            ultimateBarUI.slider.maxValue = playerStatus.playerRuntimeStat.ultgauge.maxValue;
            hpBarUI.slider.value = playerStatus.playerRuntimeStat.hp.Value;
            ultimateBarUI.slider.value = playerStatus.playerRuntimeStat.ultgauge.Value;
            hpBarUI.slider.minValue = playerStatus.playerRuntimeStat.hp.minValue;
            ultimateBarUI.slider.minValue = playerStatus.playerRuntimeStat.ultgauge.minValue;
            playerStatus.playerRuntimeStat.hp.onChanged += ChangeHp;
            playerStatus.playerRuntimeStat.ultgauge.onChanged += ChangeUltimate;
        }

        public void Disconnect()
        {
            playerStatus.playerRuntimeStat.hp.onChanged -= ChangeHp;
            playerStatus.playerRuntimeStat.ultgauge.onChanged -= ChangeUltimate;
        }

        private void ChangeHp(int _, int __)
        {
            hpBarUI.slider.value = playerStatus.playerRuntimeStat.hp.Value;
        }

        private void ChangeUltimate(int _, int __)
        {
            ultimateBarUI.slider.value = playerStatus.playerRuntimeStat.ultgauge.Value;
        }
    }
}
