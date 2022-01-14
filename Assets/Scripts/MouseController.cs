using UnityEngine;

public class MouseController : MonoBehaviour
{
    private static MouseController instance = null;
    [SerializeField] private GameObject[] levelManScripts;
    public int level;
    public static MouseController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("MouseController").AddComponent<MouseController>();
            }
            return instance;
        }
    }
    private Vector3 mouseWorldPosition;
    private void Awake()
    {
        instance = this;
    }
    public Vector3 GetMouseWorldPosition()
    {
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0;

        return mouseWorldPosition;
    }
}
