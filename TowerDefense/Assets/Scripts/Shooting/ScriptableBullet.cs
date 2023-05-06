using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletType", menuName = "ScriptableObjects/Bullet")]
public class ScriptableBullet : ScriptableObject
{
    public TurretType type;
    public Bullet bullet;
    Queue<Bullet> usedBullets;

    private void OnEnable()
    {
        usedBullets = new();
    }

    public Bullet RetrieveBullet(out bool used)
    {
        used = true;
        if(usedBullets.Count == 0)
        {
            used = false;
            return bullet;
        }
        return usedBullets.Dequeue();
    }

    public void InsertBullet(Bullet bullet)
    {
        usedBullets.Enqueue(bullet);
    }
}
