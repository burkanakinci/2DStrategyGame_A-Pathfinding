using UnityEngine;


public class PowerPlantController : MonoBehaviour
{
    [SerializeField] private UtilData powerPlantData;
    private void OnMouseDown()
    {
        UIController.Instance.ShowInformation(powerPlantData.buildSprite, powerPlantData.buildName, powerPlantData.productSprite, powerPlantData.productName);
    }
}
