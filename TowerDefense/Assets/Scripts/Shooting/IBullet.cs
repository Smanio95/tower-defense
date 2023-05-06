using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBullet
{
    void Exec(Transform muzzle, float additionalDmg);
}
