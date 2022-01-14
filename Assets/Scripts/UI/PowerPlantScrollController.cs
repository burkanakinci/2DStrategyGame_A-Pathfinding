using UnityEngine;
using UnityEngine.EventSystems;

public class PowerPlantScrollController : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        UIController.Instance.scrollItemController.ClickPowerPlant();
    }
    private void OnDisable()
    {
        //ObjectPool.Instance.scrollPowerPlantPool.Add(this.gameObject);
    }
}
