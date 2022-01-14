using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SoldierScrollController : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        UIController.Instance.scrollItemController.ClickSoldier();
    }
    private void OnDisable()
    {
       // ObjectPool.Instance.scrollSoldierPool.Add(this.gameObject);
    }
}
