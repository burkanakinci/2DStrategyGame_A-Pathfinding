using UnityEngine;
using UnityEngine.EventSystems;

public class BarrackScrollController : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        UIController.Instance.scrollItemController.ClickBarrack();
    }
    private void OnDisable()
    {
        //ObjectPool.Instance.scrollBarrackPool.Add(this.gameObject);
    }
}
