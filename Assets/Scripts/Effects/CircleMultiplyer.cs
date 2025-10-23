using UnityEngine;
using System.Collections;

public class CircleMultiplyer : MonoBehaviour
{
    [SerializeField] private float targetRadius = 2f; 
    [SerializeField] private float speed = 1f;       

    private Coroutine fadeRoutine;

    public void StartFade()
    {
        if (fadeRoutine == null)
            fadeRoutine = StartCoroutine(FadeRoutine());
    }

    private IEnumerator FadeRoutine()
    {
        float current = transform.localScale.x;

        while (current < targetRadius)
        {
            current += (1f + current) * speed * Time.deltaTime;

            if (current > targetRadius)
            {
                current = targetRadius;
            }
            transform.localScale = new Vector3(current, current, 1f);
            yield return null;
        }

        fadeRoutine = null;
    }
}