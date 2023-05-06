using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectionManager : MonoBehaviour
{
    private SelectionInfo currentSelected;

    public void SetBuilding(SelectionInfo info) => currentSelected = info;

    public Building RetrieveBuilding() { return currentSelected != null ? currentSelected.GetBuilding() : null; }

    public void UpdateAvailables()
    {
        currentSelected.UpdateAvailables();
        currentSelected = null;
    }

}
