using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter
{
    readonly TurretType type;
    readonly Transform muzzle;
    readonly BulletManager BM;
    readonly LayerMask mask;
    float radius;
    float rateo;
    float additionalDmg = 0;


    public Shooter(Transform _muzzle, TurretType _type, float _radius, float _rateo, LayerMask _mask, BulletManager _BM)
    {
        muzzle = _muzzle;
        type = _type;
        radius = _radius;
        rateo = _rateo;
        mask = _mask;
        BM = _BM;
    }

    public void Shoot()
    {
        Bullet bullet = BM.RetrieveBullet(type);
        bullet.Exec(muzzle, additionalDmg);
    }

    public void UpdateDmg(float _additionalDmg)
    {
        additionalDmg += _additionalDmg;
    }

    public Transform RetrieveTarget(Vector3 origin)
    {
        Collider[] hits = Physics.OverlapSphere(origin, radius, mask);
        if (hits.Length > 0)
        {
            Transform closerHit = hits[0].transform;
            foreach (Collider hit in hits)
            {
                if (Vector3.Distance(origin, closerHit.position) > Vector3.Distance(origin, hit.transform.position))
                {
                    closerHit = hit.transform;
                }
                return closerHit;
            }
        }
        return null;
    }

    public Transform Attack(ref float elapsed, Vector3 origin)
    {
        Transform target = RetrieveTarget(origin);
        if (elapsed >= rateo && Physics.Raycast(muzzle.position, muzzle.forward, mask))
        {
            elapsed = 0;
            Shoot();
        }
        return target;
    }

    public void SetBuff(BuffType buffType, float value)
    {
        switch (buffType)
        {
            case BuffType.Rateo:
                rateo /= value;
                break;
            case BuffType.Range:
                radius += value;
                break;
            case BuffType.Dmg:
                additionalDmg += value;
                break;
        }
    }

    public void RemoveBuff(BuffType buffType, float value)
    {
        switch (buffType)
        {
            case BuffType.Rateo:
                rateo *= value;
                break;
            case BuffType.Range:
                radius -= value;
                break;
            case BuffType.Dmg:
                additionalDmg -= value;
                break;
        }
    }

}


