using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuildingText : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] SelectionInfo selectionInfo;

    private void Update()
    {
        text.text = selectionInfo.GetUpdatedString();
    }
    
}
