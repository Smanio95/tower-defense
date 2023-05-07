using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct BuffInfo
{
    public bool active;
    public BuffType type;
    public float value;

    public BuffInfo(BuffType _type, float _value)
    {
        type = _type;
        value = _value;
        active = true;
    }
}

public class Buff : Building, IBuff
{
    [SerializeField] BuffType buffType;
    [SerializeField] float valueChange;

    private readonly List<Turret> buffedTurrets = new();

    private new void Awake()
    {
        base.Awake();
        type = BuildingType.Buff;
    }

    public void ExecuteBuff()
    {
        foreach (Turret turret in buffedTurrets)
        {
            turret.SetBuff(buffType, valueChange);
        }
    }

    public void RemoveBuff()
    {
        foreach (Turret turret in buffedTurrets)
        {
            turret.RemoveBuff(buffType, valueChange);
        }
    }

    public void UpdateBuff(List<Turret> _buffedTurrets)
    {
        RemoveBuff();
        buffedTurrets.Clear();
        foreach (Turret t in _buffedTurrets)
        {
            buffedTurrets.Add(t);
        }
        ExecuteBuff();
    }

}
