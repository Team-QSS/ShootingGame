using System.Collections;
using UnityEngine;

public class Bounding : MonoBehaviour
{
    [SerializeField] private float boundingAmount;
    private Coroutine _boundingFlow;

    public void Bound(Vector2 dir)
    {
        if (_boundingFlow != null)
        {
            StopCoroutine(_boundingFlow);
        }
        _boundingFlow = StartCoroutine(BoundFlow(boundingAmount * dir.x));
    }

    private IEnumerator BoundFlow(float degree)
    {
        var currentDeg = gameObject.transform.eulerAngles.y;
        var targetDeg = degree;

        while (Mathf.Abs(Mathf.DeltaAngle(currentDeg, targetDeg)) > 0.1f)
        {
            currentDeg = Mathf.LerpAngle(currentDeg, targetDeg, Time.deltaTime * 10f);
            gameObject.transform.eulerAngles = new Vector3(0, currentDeg, 0);
            yield return null;
        }

        gameObject.transform.eulerAngles = new Vector3(0, targetDeg, 0);
    }
}

