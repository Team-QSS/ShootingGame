using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySkillCooldown
{
    private Dictionary<EntityMoves, float> _coolDownSetData = new();
    private Dictionary<EntityMoves, float> _runtimeCooldownData = new();

    public void AddPattern(EntityMoves name, float coolDown)
    {
        if (!_coolDownSetData.ContainsKey(name))
        {
            _coolDownSetData.Add(name, coolDown);
            _runtimeCooldownData.Add(name,0);
        }
    }

    public void RemovePattern(EntityMoves name)
    {
        if (_coolDownSetData.ContainsKey(name))
        {
            _coolDownSetData.Remove(name);
            _runtimeCooldownData.Remove(name);
        }
    }

    public float GetCooldown(EntityMoves name)
    {
        return _runtimeCooldownData[name];
    }
    
    public void DecreaseCooldown(EntityMoves name,float amount)
    {
        _runtimeCooldownData[name] -= amount;
    }

    public void DecreaseCooldownAll(float amount)
    {
        var keys = _runtimeCooldownData.Keys.ToList();
        foreach (var key in keys)
        {
            _runtimeCooldownData[key] -= amount;
        }
    }


    public bool CheckToUseSkill(EntityMoves name)
    {
        if (_runtimeCooldownData.ContainsKey(name)&&_runtimeCooldownData[name]<=0)
        {
            _runtimeCooldownData[name] = _coolDownSetData[name];
            return true;
        }
        return false;
    }

    public void SetSkillCool(EntityMoves name,float amount)
    {
        if(_runtimeCooldownData.ContainsKey(name))
        {
            _runtimeCooldownData[name] = amount;
        }
    }
    public void ReSetSkillCool(EntityMoves name)
    {
        if(_runtimeCooldownData.ContainsKey(name))
        {
            _runtimeCooldownData[name] = _coolDownSetData[name];
        }
    }

}
