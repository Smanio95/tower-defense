using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BuildingType
{
    Buff,
    Turret
}

public abstract class Building : MonoBehaviour
{
    public BuildingType type;
    [HideInInspector] public float Height { get; private set; }

    protected void Awake()
    {
        Height = transform.localScale.y;
    }
}
