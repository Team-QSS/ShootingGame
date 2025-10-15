using ScriptableObjectScripts;
using UnityEngine;
using UtilScripts;

namespace ManagerScripts
{
    public class GameManager : SingleMono<GameManager>
    {
        [Header("Main Game Statics")]
        [SerializeField] private StageInfo[] stages;
        private int _currentStage;
        
        private void Start()
        {
            ActivateNextStage();
        }
        
        public void ActivateNextStage()
        {
            if (_currentStage >= stages.Length) return;
            StageManager.Instance.StartStage(stages[_currentStage]);
            _currentStage++;
        }
    }
}
