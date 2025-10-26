using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : ButtonUI
{
    [SerializeField] private float fadeWaitTime = 1.5f;
    [SerializeField] private float startWaitTime = 0.8f;
    [SerializeField] private string sceneName = "PickPanel";
    public event Action onStartEarly;
    public event Action onStartLate;

    private Coroutine startFlowRoutine;

    public override void OnInteract()
    {
        if (startFlowRoutine == null)
        {
            startFlowRoutine = StartCoroutine(StartFlow());
        }

    }

    private IEnumerator StartFlow()
    {
        onStartEarly?.Invoke();
        yield return new WaitForSeconds(fadeWaitTime);
        onStartLate?.Invoke();
        yield return new WaitForSeconds(startWaitTime);
        startFlowRoutine = null;
        SceneManager.LoadScene(sceneName);
    }
}