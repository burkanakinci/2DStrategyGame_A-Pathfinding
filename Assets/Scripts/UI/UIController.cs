using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.UI;
using TMPro;

public class UIController : MonoBehaviour
{

    private static UIController instance = null;
    public static UIController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("UIController").AddComponent<UIController>();
            }
            return instance;
        }
    }
    public ScrollItemController scrollItemController;
    [SerializeField] private Image buildImage;
    [SerializeField] private TMPro.TextMeshProUGUI buildNameText;
    [SerializeField] private Image productionImage;
    [SerializeField] private TMPro.TextMeshProUGUI productionNameText;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        scrollItemController = GetComponent<ScrollItemController>();
    }

    public void ShowInformation(Sprite buildSprite, string buildName, Sprite productionSprite, string productionName)
    {
        buildImage.sprite = buildSprite;
        buildNameText.text = buildName;

        productionImage.sprite = productionSprite;
        productionNameText.text = productionName;
    }
}
