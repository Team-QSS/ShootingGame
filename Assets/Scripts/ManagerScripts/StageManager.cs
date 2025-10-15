using ScriptableObjectScripts;
using UtilScripts;

namespace ManagerScripts
{
    public class StageManager : SingleMono<StageManager>
    {
        private StageInfo _stageInfo;
        private int _waveIndex;

        private void Start()
        {
            ActivateNextWave();
        }

        public void StartStage(StageInfo stageInfo)
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
