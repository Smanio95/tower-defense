using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOEBullet : Bullet
{
    [SerializeField] float hitRadius = 5;
    [SerializeField] LayerMask enemyMask;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    new void Update() { }

    public override void Exec(Transform muzzle, float additionalDmg = 0)
    {
        base.Exec(muzzle, additionalDmg);

        if(rb == null) rb = GetComponent<Rigidbody>();

        rb.AddForce(muzzle.transform.forward * speed, ForceMode.Impulse);
    }

    public override void OnHit(Collider other)
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, hitRadius, enemyMask);
        if (hits.Length > 0)
        {
            foreach (Collider hit in hits)
            {
                Enemy enemy = hit.GetComponent<Enemy>();
                if (enemy != null) enemy.TakeDmg(dmg);
            }
        }
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        rb.velocity = Vector3.zero;
    }
}
