using UnityEngine;

[ExecuteAlways]
public class HologramTimeSetter : MonoBehaviour
{
    private static readonly int UnscaledTimeID = Shader.PropertyToID("_UnscaledTime");

    void Update()
    {
        Shader.SetGlobalFloat(UnscaledTimeID, Time.unscaledTime);
    }
}