using UnityEngine;
using UnityEngine.UI;
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
    [SerializeField] private TextMeshProUGUI buildNameText;
    [SerializeField] private Image productionImage;
    [SerializeField] private TextMeshProUGUI productionNameText;
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
