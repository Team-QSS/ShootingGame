using System.Collections;
using UnityEngine;

public class CameraManager : SceneSingleMono<CameraManager>
{
    [SerializeField] private float moveSpeed = 3f; 
    public Transform target;                   
    private Coroutine _moveRoutine;               
    private Coroutine _shakeRoutine;               

    private void Start()
    {
        if (target != null)
            _moveRoutine = StartCoroutine(FollowTarget());
    }

    public void SetTarget(Transform newTarget)
    {
        if (target == newTarget) return;

        target = newTarget;
        
        if (_moveRoutine != null)
        {
            StopCoroutine(_moveRoutine);
            _moveRoutine = null;
        }
        
        if (target != null)
            _moveRoutine = StartCoroutine(FollowTarget());
    }

    private IEnumerator FollowTarget()
    {
        while (target != null)
        {
            Vector3 targetPos = new Vector3(target.position.x, target.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }

        _moveRoutine = null;
    }
    
    public void ShakeCamera(float duration = 0.3f, float magnitude = 0.2f)
    {
        if (_shakeRoutine != null)
        {
            StopCoroutine(_shakeRoutine);
            _shakeRoutine = null;
        }
        _shakeRoutine = StartCoroutine(ShakeRoutine(duration, magnitude));
    }

    private IEnumerator ShakeRoutine(float duration, float magnitude)
    {
        Vector3 originalPos = transform.position;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float offsetX = Random.Range(-1f, 1f) * magnitude;
            float offsetY = Random.Range(-1f, 1f) * magnitude;
            transform.position = new Vector3(originalPos.x + offsetX, originalPos.y + offsetY, originalPos.z);

            elapsed += Time.deltaTime;
            yield return null;
        }
        
        transform.position = originalPos;
        _shakeRoutine = null;
    }
}
