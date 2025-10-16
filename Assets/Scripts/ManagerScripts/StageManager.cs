using ScriptableObjectScripts;
using UtilScripts;

namespace ManagerScripts
{
    public class StageManager : SingleMono<StageManager>
    {
        private StageInfoSO _stageInfo;
        private int _waveIndex;

        private void Start()
        {
            ActivateNextWave();
        }

        public void StartStage(StageInfoSO stageInfo)
        {
            _stageInfo = stageInfo;
        }
        
        public void ActivateNextWave()
        {
            if (_waveIndex >= _stageInfo.waves.Length) return;
            WaveManager.Instance.StartWave(_stageInfo.waves[_waveIndex]);
            _waveIndex++;
        }
    }
}
