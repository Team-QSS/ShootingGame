using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private Dictionary<string, Action<GameObject>> _hitHash = new();

    private void Start()
    {
        _hitHash.Add("Enemy",HitByEnemy);
        _hitHash.Add("Damager",HitByDamager);
        _hitHash.Add("Item",HitByItem);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_hitHash.ContainsKey(collision.tag))
        {
            _hitHash[collision.tag](collision.gameObject);
        }
    }

    public void HitByEnemy(GameObject other)
    {
        //other.GetComponent<EnemyStatus>()
    }

    public void HitByDamager(GameObject other)
    {
        
    }

    public void HitByItem(GameObject other)
    {
        
    }
    
}
