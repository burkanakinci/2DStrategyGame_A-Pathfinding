using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "UtilData", menuName = "Util Data")]
public class UtilData : ScriptableObject
{
    public Sprite buildSprite;
    public string buildName = "Build";
    public Sprite productSprite;
    public string productName = "Production";

}
