using ScriptableObjectScripts;
using UnityEngine;
using UtilScripts;

namespace ManagerScripts
{
    public class WaveManager : SingleMono<WaveManager>
    {
        private int _enemyIndex;
        private int _enemyCount;
        private float _startTime;

        private float FlowedTime => Time.fixedTime - _startTime;

        [Header("Wave Info")]
        private WaveInfo _waveInfo;
        
        public void StartWave(WaveInfo waveInfo)
        {
            _startTime = Time.fixedTime;
            _waveInfo = waveInfo;
        }

        public void Update()
        {
            if (_waveInfo.enemyList.Length <= _enemyIndex)
            {
                if (_enemyCount <= 0) StageManager.Instance.ActivateNextWave();
                return;
            }
            if (_waveInfo.enemyList[_enemyIndex] >= FlowedTime)
            {
                _enemyCount++;
                // 추후 적 코드 작성시 추가
                // enemyList[_enemyIndex].Spawn();
                // enemyList[_enemyIndex].OnRemove += () => _enemyCount--;
            }
        }
    }
}
