using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TurretStats", menuName = "ScriptableObjects/TurretStats")]
public class TurretStats : ScriptableObject
{
    [Header("Stats")]
    public TurretType turretType;
    public LayerMask enemyMask;
    public float radius = 10;
    public float rateo = 2;

    [Header("Rotation")]
    public float rotationSpeed = 20;
    public float muzzleSpeed = 100;
}
