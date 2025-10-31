using UnityEngine;

public class UnscaledAnimator : MonoBehaviour
{
    public Animator animator;

    void Update()
    {
        animator.Update(Time.unscaledDeltaTime);
    }
}