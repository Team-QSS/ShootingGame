using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//부트 스트래핑 부분 적들을 생성하거나 초기화하는 부분은 지금 적과 바꿔야함
public class BootStrapper : MonoBehaviour
{
    [SerializeField] private List<GameObject> strapNeeded;
    private void Start()
    {
        StartCoroutine(BootFlow());
    }

    private IEnumerator BootFlow()
    {
        foreach (var strap in strapNeeded)
        {
            strap.SetActive(true);
        }
        yield return new WaitForEndOfFrame();
    }
}
