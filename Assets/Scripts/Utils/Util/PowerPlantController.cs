using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerPlantController : MonoBehaviour
{
    [SerializeField] private UtilData powerPlantData;
    private void OnMouseDown()
    {
        UIController.Instance.ShowInformation(powerPlantData.buildSprite, powerPlantData.buildName, powerPlantData.productSprite, powerPlantData.productName);
    }
}
