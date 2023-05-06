using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class HealthObject : MonoBehaviour
{
    [SerializeField] protected float HP = 100;
    protected float initialHP;
    [SerializeField] protected Image healthImg;

    protected UIHealth healthUpdater;

    private void Awake()
    {
        initialHP = HP;
        healthUpdater = GenerateHealthUpdater();
    }

    public virtual UIHealth GenerateHealthUpdater()
    {
        return new(healthImg);
    }

    protected virtual void Update()
    {
        healthUpdater.Update(HP / initialHP);
    }

    public void TakeDmg(float dmg)
    {
        HP -= dmg;
        if (HP <= 0) OnDeath();
    }

    protected abstract void OnDeath();

}
