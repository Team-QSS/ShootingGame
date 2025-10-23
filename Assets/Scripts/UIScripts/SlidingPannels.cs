using Unity.Collections;
using UnityEngine;

public class SlidingPannels : MonoBehaviour
{
    [ReadOnly] public string appearHash = "Appear";
    [ReadOnly] public string disappearHash = "Disappear";
    [SerializeField] Animator ani;

    public void Appear()
    {
        ani.SetTrigger(appearHash);
    }

    public void Disappear()
    {
        ani.SetTrigger(disappearHash);
    }
    
}
