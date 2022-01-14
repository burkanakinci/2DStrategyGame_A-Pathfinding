using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarrackController : MonoBehaviour
{
    [SerializeField] private UtilData barrackData;
    private void OnMouseDown()
    {
        UIController.Instance.ShowInformation(barrackData.buildSprite, barrackData.buildName, barrackData.productSprite, barrackData.productName);
    }
}
