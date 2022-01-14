using UnityEngine;


public class BarrackController : MonoBehaviour
{
    [SerializeField] private UtilData barrackData;
    private void OnMouseDown()
    {
        UIController.Instance.ShowInformation(barrackData.buildSprite, barrackData.buildName, barrackData.productSprite, barrackData.productName);
    }
}
