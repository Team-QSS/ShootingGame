using System;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using Unity.VisualScripting;

public class ButtonUI : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler,IUIInteraction
{
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private float hoverScale = 1.2f;  
    [SerializeField] private float duration = 0.2f;   
    [SerializeField] private int buttonIndex;
    
    public event Action<int> onHover;

    private Vector3 originalScale;
    private Coroutine scaleCoroutine;

    private void Awake()
    {
        originalScale = rectTransform.localScale;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnInteract();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        onHover?.Invoke(buttonIndex);
        StartScaleCoroutine(hoverScale);
    }

    public void ExitInteraction()
    {
        StartScaleCoroutine(1f);
    }
    
    public virtual void OnInteract()
    {
        
    }
    

    private void StartScaleCoroutine(float targetScale)
    {
        if (scaleCoroutine != null)
            StopCoroutine(scaleCoroutine);

        scaleCoroutine = StartCoroutine(ScaleCoroutine(targetScale));
    }

    private IEnumerator ScaleCoroutine(float targetScale)
    {
        Vector3 startScale = rectTransform.localScale;
        Vector3 endScale = originalScale * targetScale;

        float time = 0f;
        while (time < duration)
        {
            time += Time.deltaTime;
            rectTransform.localScale = Vector3.Lerp(startScale, endScale, time / duration);
            yield return null;
        }

        rectTransform.localScale = endScale;
        scaleCoroutine = null;
    }
}