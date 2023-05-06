using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuildingPlaceHolder : MonoBehaviour
{
    [Header("Refs")]
    [SerializeField] BulletManager BM;
    [SerializeField] SelectionManager SM;

    [Header("Stats")]
    [SerializeField] int maxBlocks = 4;

    [Header("Txt")]
    [SerializeField] TMP_Text text;

    List<Buff> buffList = new();
    List<Turret> turretList = new();

    private float currentHeight;

    private void Awake()
    {
        if (BM == null) BM = FindObjectOfType<BulletManager>();

        if (SM == null) SM = FindObjectOfType<SelectionManager>();

        currentHeight = transform.position.y;

        text.text = maxBlocks.ToString();
    }

    public void PlaceBuilding()
    {
        Building b = SM.RetrieveBuilding();

        if (b == null 
            || buffList.Count + turretList.Count >= maxBlocks
            || (b.type == BuildingType.Buff && turretList.Count == 0)) return;

        SM.UpdateAvailables();

        InstantiateBuilding(ref b);

        ManageBuilding(b);
        
    }

    void InstantiateBuilding(ref Building b)
    {
        b = Instantiate(b, new Vector3(transform.position.x, currentHeight, transform.position.z), transform.rotation, transform);

        currentHeight += b.transform.localScale.y;
    }

    void ManageBuilding(Building b)
    {
        switch (b.type)
        {
            case BuildingType.Buff:
                buffList.Add((Buff)b);
                UpdateBuffs();
                break;
            case BuildingType.Turret:
                ManageTurret((Turret)b);
                UpdateBuffs();
                break;
        }

        text.text = (maxBlocks - buffList.Count - turretList.Count).ToString();
    }

    void UpdateBuffs()
    {
        foreach (Buff b in buffList) b.UpdateBuff(turretList);
    }

    void ManageTurret(Turret turret)
    {
        turret.BM = BM;
        turretList.Add(turret);
    }
}
