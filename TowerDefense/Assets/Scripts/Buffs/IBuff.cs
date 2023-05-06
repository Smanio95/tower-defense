using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BuffType
{
    Rateo,
    Dmg,
    Range
}

public interface IBuff
{
    void ExecuteBuff();

    void RemoveBuff();

    void UpdateBuff(List<Turret> _buffedTurrets);
}
