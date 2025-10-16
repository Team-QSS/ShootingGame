using UnityEngine;

namespace ScriptableObjectScripts
{
    [CreateAssetMenu(fileName = "StageInfoSO", menuName = "Scriptable Objects/StageInfoSO)")]
    public class StageInfoSO : ScriptableObject
    {
        [SerializeField] public WaveInfoSO[] waves;
    }
}
