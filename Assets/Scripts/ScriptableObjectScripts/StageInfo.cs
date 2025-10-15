using UnityEngine;

namespace ScriptableObjectScripts
{
    [CreateAssetMenu(fileName = "StageInfo", menuName = "Scriptable Objects/StageInfo")]
    public class StageInfo : ScriptableObject
    {
        [SerializeField] public WaveInfo[] waves;
    }
}
