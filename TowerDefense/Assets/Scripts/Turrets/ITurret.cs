using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TurretType
{
    Single,
    AOE,
    Gatling
}

public interface ITurret
{
    Shooter TurretShooter { get; }

    void Move(Transform target);
    void SetBuff(BuffType type, float value);
    void RemoveBuff(BuffType type, float value);

}
