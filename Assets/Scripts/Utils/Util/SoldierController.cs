using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoldierController : MonoBehaviour
{
    [SerializeField] private UtilData soldierData;
    private void OnMouseDown()
    {
        UIController.Instance.ShowInformation(soldierData.buildSprite, soldierData.buildName, soldierData.productSprite, soldierData.productName);
    }
}
