using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollItemController : MonoBehaviour
{
    private GameObject barrackBorder, soldierBorder, powerPlantBorder;

    private void Start()
    {
        barrackBorder = GameObject.FindGameObjectWithTag("BarrackBorder");
        powerPlantBorder = GameObject.FindGameObjectWithTag("PowerPlantBorder");
        soldierBorder = GameObject.FindGameObjectWithTag("SoldierBorder");

        barrackBorder.SetActive(false);
        powerPlantBorder.SetActive(false);
        soldierBorder.SetActive(false);
    }
    public void ClickBarrack()
    {
        barrackBorder.SetActive(true);
        powerPlantBorder.SetActive(false);
        soldierBorder.SetActive(false);
    }
    public void ClickPowerPlant()
    {
        barrackBorder.SetActive(false);
        powerPlantBorder.SetActive(true);
        soldierBorder.SetActive(false);
    }
    public void ClickSoldier()
    {
        barrackBorder.SetActive(false);
        powerPlantBorder.SetActive(false);
        soldierBorder.SetActive(true);
    }
}
