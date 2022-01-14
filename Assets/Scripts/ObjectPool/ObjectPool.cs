using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectPool : MonoBehaviour
{
    private static ObjectPool instance = null;
    public static ObjectPool Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("ObjectPool").AddComponent<ObjectPool>();
            }
            return instance;
        }
    }
    private void Awake()
    {
        instance = this;
    }
    public List<GameObject> scrollSoldierPool = new List<GameObject>();
    public GameObject scrollSoldiers;
    public List<GameObject> scrollBarrackPool = new List<GameObject>();
    public GameObject scrollBarrack;
    public List<GameObject> scrollPowerPlantPool = new List<GameObject>();
    public GameObject scrollPowerPlant;
    private Transform tempTransform;
    [SerializeField] private GameObject tempGameObject;

    public Transform SpawnScrollObject(GameObject _scrollObject, Transform scrollContent)
    {
        tempGameObject = _scrollObject;

        if (_scrollObject == scrollBarrack)
        {
            if (scrollBarrackPool.Count > 0)
            {
                tempTransform = scrollBarrackPool[0].transform;
                scrollBarrackPool[0].gameObject.SetActive(true);
                scrollBarrackPool[0].transform.SetParent(scrollContent);
                scrollBarrackPool.Remove(scrollBarrackPool[0]);
                scrollBarrackPool.Add(_scrollObject);
            }
            else
            {
                tempTransform = Instantiate(scrollBarrack, scrollContent).transform;
                scrollBarrackPool.Add(_scrollObject);
            }
        }
        if (_scrollObject == scrollPowerPlant)
        {
            if (scrollPowerPlantPool.Count > 0)
            {
                tempTransform = scrollPowerPlantPool[0].transform;
                scrollPowerPlantPool[0].gameObject.SetActive(true);
                scrollPowerPlantPool[0].transform.SetParent(scrollContent);
                scrollPowerPlantPool.Remove(scrollPowerPlantPool[0]);
                scrollPowerPlantPool.Add(_scrollObject);
            }
            else
            {
                tempTransform = Instantiate(scrollPowerPlant, scrollContent).transform;
                scrollPowerPlantPool.Add(_scrollObject);
            }
        }
        else
        {
            if (scrollSoldierPool.Count > 0)
            {
                tempTransform = scrollSoldierPool[0].transform;
                scrollSoldierPool[0].gameObject.SetActive(true);
                scrollSoldierPool[0].transform.SetParent(scrollContent);
                scrollSoldierPool.Remove(scrollSoldierPool[0]);
                scrollSoldierPool.Add(_scrollObject);
            }
            else
            {
                tempTransform = Instantiate(scrollSoldiers, scrollContent).transform;
                scrollSoldierPool.Add(_scrollObject);

            }
        }


        _scrollObject.transform.SetParent(null);
        _scrollObject.SetActive(false);


        return tempTransform;
    }
}
