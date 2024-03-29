﻿using UnityEngine;


public class SoldierController : MonoBehaviour
{
    [SerializeField] private UtilData soldierData;
    private void OnMouseDown()
    {
        UIController.Instance.ShowInformation(soldierData.buildSprite, soldierData.buildName, soldierData.productSprite, soldierData.productName);

        PathFinding.Instance.GetGrid().GetGridObject(transform.position).SetIsWalkable(true);
        Testing.Instance.soldierMovement = GetComponent<SoldierMovement>();
    }
}
