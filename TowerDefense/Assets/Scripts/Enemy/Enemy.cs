using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : HealthObject
{
    [SerializeField] RectTransform healthCanvas;
    [SerializeField] float speed = 5;
    [SerializeField] float bodyDmg = 20;

    [HideInInspector] public EnemyManager EM;

    private EnemyMovement enemyMovement;

    public override UIHealth GenerateHealthUpdater()
    {
        return new UIRotatingHealth(healthCanvas, transform, healthImg);
    }

    private void Start()
    {
        enemyMovement = new(transform, EM, speed);
    }

    protected override void Update()
    {
        base.Update();
        MoveEnemy();
    }

    void MoveEnemy()
    {
        enemyMovement.MoveEnemy();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(Tags.Base))
        {
            BaseController baseController = collision.collider.GetComponent<BaseController>();
            if(baseController != null) baseController.TakeDmg(bodyDmg);

            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        ResetEnemy();
        EM.AddEnemy(this);
    }

    private void ResetEnemy()
    {
        enemyMovement.OnDisable();
        HP = initialHP;
    }

    protected override void OnDeath()
    {
        gameObject.SetActive(false);
    }
}
