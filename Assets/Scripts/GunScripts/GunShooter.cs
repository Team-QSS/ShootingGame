using System.Collections;
using UnityEngine;

public class GunShooter : MonoBehaviour
{
    [Header("총 프리팹")]
    [SerializeField] private GameObject gunPrefab;

    [Header("발사 간격 (초)")]
    [SerializeField] private float fireInterval = 1f;

    private bool canFire = true;

    private void Start()
    {
        StartCoroutine(FireRoutine());
    }
    
    private IEnumerator FireRoutine()
    {
        while (true)
        {
            if (canFire && gunPrefab != null)
            {
                FireGun();
            }
            yield return new WaitForSeconds(fireInterval);
        }
    }
    
    private void FireGun()
    {
        Instantiate(gunPrefab, transform.position, transform.rotation);
    }
    
    public void SetCanFire(bool value)
    {
        canFire = value;
    }
    
    public void SetGunPrefab(GameObject newGun)
    {
        if (newGun != null)
            gunPrefab = newGun;
    }
}