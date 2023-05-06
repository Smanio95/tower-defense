using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] ScriptableBullet[] scriptableBullets;

    private void Awake()
    {
        Bullet.OnBulletHit += InsertBullet;
    }

    ScriptableBullet RetrieveScriptable(TurretType type)
    {
        foreach(ScriptableBullet scriptable in scriptableBullets)
        {
            if (scriptable.type == type) return scriptable;
        }
        return null;
    }

    public Bullet RetrieveBullet(TurretType type)
    {
        ScriptableBullet s = RetrieveScriptable(type);
        Bullet bullet = s.RetrieveBullet(out bool used);

        if (used)
        {
            bullet.gameObject.SetActive(true);
            return bullet;
        }
        return Instantiate(bullet, transform);
    }

    void InsertBullet(TurretType type, Bullet bullet)
    {
        ScriptableBullet s = RetrieveScriptable(type);
        s.InsertBullet(bullet);
    }

    private void OnDestroy()
    {
        Bullet.OnBulletHit -= InsertBullet;
    }

}
