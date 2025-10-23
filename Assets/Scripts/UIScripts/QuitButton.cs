using System;
using System.Collections;
using UnityEngine;

public class QuitButton : ButtonUI
{
    [SerializeField] private float quitWaitTime = 1.5f;
    [SerializeField] private float endWaitTime = 0.8f;
    public event Action onQuitEarly;
    public event Action onQuitLate;

    private Coroutine quitFlowRoutine;

    public override void OnInteract()
    {
        if (quitFlowRoutine == null)
            quitFlowRoutine = StartCoroutine(QuitFlow());
    }

    private IEnumerator QuitFlow()
    {
        onQuitEarly?.Invoke();
        yield return new WaitForSeconds(quitWaitTime);
        onQuitLate?.Invoke();
        yield return new WaitForSeconds(endWaitTime);
        quitFlowRoutine = null;
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; 
#else
        Application.Quit(); 
#endif
    }
}

