using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Building, ITurret
{
    [Header("Ref")]
    public BulletManager BM;
    [SerializeField] Transform muzzleMesh;
    [SerializeField] Transform actualMuzzle;

    [Header("Stats")]
    [SerializeField] TurretStats turretStats;

    private float elapsed = 0;
    private BuffInfo pendingBuff;

    private Shooter shooter;
    public Shooter TurretShooter { get => shooter; }

    protected new void Awake()
    {
        base.Awake();

        type = BuildingType.Turret;
    }

    private void Start()
    {
        shooter = new(actualMuzzle, turretStats.turretType, turretStats.radius, turretStats.rateo, turretStats.enemyMask, BM);
    }

    void Update()
    {
        ExecBuff();

        elapsed += Time.deltaTime;
        Transform target = shooter.Attack(ref elapsed, transform.position);

        if (target != null) Move(target);
    }

    // MOVEMENT
    public void Move(Transform target)
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(new Vector3(target.position.x, transform.position.y, target.position.z) - transform.position), Time.deltaTime * turretStats.rotationSpeed);

        Vector3 directionAngle = Quaternion.LookRotation(target.position - muzzleMesh.position).eulerAngles;
        muzzleMesh.localRotation = Quaternion.Euler(new(Mathf.MoveTowardsAngle(muzzleMesh.localRotation.eulerAngles.x, directionAngle.x, Time.deltaTime * turretStats.muzzleSpeed), 0, 0));
    }


    // BUFFS
    void ExecBuff()
    {
        if (pendingBuff.active)
        {
            shooter.SetBuff(pendingBuff.type, pendingBuff.value);
            pendingBuff.active = false;
        }
    }

    public void SetBuff(BuffType buffType, float value) => pendingBuff = new(buffType, value);
    

    public void RemoveBuff(BuffType buffType, float value) => shooter.RemoveBuff(buffType, value);
    
}

