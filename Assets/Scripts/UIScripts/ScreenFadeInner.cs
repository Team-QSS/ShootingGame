using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenFadeInner : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float waitTime;
    private string _defaultTrigger = "Fade";
    private Coroutine _fadeRoutine;

    public void Fade()
    {
        if (_fadeRoutine == null)
            _fadeRoutine = StartCoroutine(FadeRoutine());
    }

    private IEnumerator FadeRoutine()
    {
        animator.SetTrigger(_defaultTrigger);
        AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
        float duration = info.length;
        yield return new WaitForSeconds(duration);
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadSceneAsync("InGameScene");
        _fadeRoutine = null;
    }
}