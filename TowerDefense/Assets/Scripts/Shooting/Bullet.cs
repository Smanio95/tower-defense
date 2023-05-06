using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IBullet
{
    [SerializeField] TurretType type;
    [SerializeField] protected float speed = 5;
    [SerializeField] protected float dmg = 0;
    private float initialDmg = 0;

    public delegate void BulletHit(TurretType type, Bullet bullet);
    public static BulletHit OnBulletHit;

    private void Awake()
    {
        initialDmg = dmg;
    }

    protected virtual void OnDisable()
    {
        dmg = initialDmg;
    }

    protected void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
    }

    public virtual void Exec(Transform muzzle, float additionalDmg = 0)
    {
        transform.SetPositionAndRotation(muzzle.position, muzzle.rotation);
        dmg += additionalDmg;
    }

    private void OnTriggerEnter(Collider other)
    {
        OnBulletHit?.Invoke(type, this);
        OnHit(other);
        gameObject.SetActive(false);
    }

    public virtual void OnHit(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null) enemy.TakeDmg(dmg);
    }

}
