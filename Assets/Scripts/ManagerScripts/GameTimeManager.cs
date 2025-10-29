using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTimeManager : SceneSingleMono<GameTimeManager>
{
    public Action<float> onClock; 
    private Coroutine timeCoroutine;
    private float elapsedTime;
    private bool isRunning = false;

    public float ElapsedTime => elapsedTime;
    public bool IsRunning => isRunning;

    private void Start()
    {
        StartClock();
    }
    
    private IEnumerator ClockRoutine()
    {
        while (true)
        {
            yield return new WaitForFixedUpdate();

            if (!isRunning)
                continue;

            elapsedTime += Time.fixedDeltaTime;
            onClock?.Invoke(elapsedTime);
        }
    }

    public void StartClock()
    {
        if (timeCoroutine == null)
            timeCoroutine = StartCoroutine(ClockRoutine());

        isRunning = true;
    }

    public void StopClock()
    {
        isRunning = false;
    }

    public void ResetClock()
    {
        elapsedTime = 0f;
        onClock?.Invoke(elapsedTime); 
    }

    public void RestartClock()
    {
        ResetClock();
        StartClock();
    }
}

