using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="SelectionInfo", menuName = "ScriptableObjects/UI/SelectionInfo")]
public class SelectionInfo : ScriptableObject
{
    [SerializeField] int maxInScene;
    [SerializeField] Building buildingPrefab;
    [SerializeField] string baseText;

    private int availableN = 0;

    private void OnEnable()
    {
        availableN = maxInScene;
    }

    public void ResetValues()
    {
        availableN = maxInScene;
    }

    public Building GetBuilding()
    {
        return availableN > 0 ? buildingPrefab : null;
    }

    public string GetUpdatedString()
    {
        return $"{baseText} {availableN}";
    }

    public void UpdateAvailables() => availableN--;
}
