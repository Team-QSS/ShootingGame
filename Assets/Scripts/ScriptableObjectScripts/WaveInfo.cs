using UnityEngine;

namespace ScriptableObjectScripts
{
    [CreateAssetMenu(fileName = "WaveInfo", menuName = "Scriptable Objects/WaveInfo")]
    public class WaveInfo : ScriptableObject
    {
        [SerializeField] public float[] enemyList; // 추후 적 추가시 타입 변경 (Enemy[])
        [SerializeField] public WaveType waveType;
    }
    
    public enum WaveType
    {
        Normal,
        Meteor,
        Boss
    }
}
