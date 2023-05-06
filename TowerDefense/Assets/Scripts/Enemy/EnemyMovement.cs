using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement
{
    readonly EnemyManager EM;
    readonly Transform enemyTransform;
    readonly float speed = 20;
    private int currentPosition = 0;
    private Vector3 nextPosition;

    public EnemyMovement(Transform _enemyTransform, EnemyManager _EM, float _speed)
    {
        enemyTransform = _enemyTransform;
        EM = _EM;
        speed = _speed;
    }

    public void MoveEnemy()
    {
        if (Vector3.Distance(enemyTransform.position, nextPosition) > 0 && currentPosition > 0)
        {
            enemyTransform.position = Vector3.MoveTowards(enemyTransform.position, nextPosition, Time.deltaTime * speed);
        }
        else
        {
            nextPosition = EM.RetrievePos(enemyTransform.position.y, ref currentPosition);
            enemyTransform.LookAt(nextPosition);
        }
    }

    public void OnDisable()
    {
        currentPosition = 0;
    }
}
