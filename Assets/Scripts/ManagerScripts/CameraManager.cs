using System.Collections;
using UnityEngine;

public class CameraManager : SceneSingleMono<CameraManager>
{
    [SerializeField] private float moveSpeed = 3f; 
    private Transform target;                   
    private Coroutine _moveRoutine;               

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
}

