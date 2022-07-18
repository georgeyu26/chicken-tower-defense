using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TowerData
{
    public float[] TowerPos;
    public int TowerHealth;
    public int TowerLevel;
    public string TowerType;
    public int TowerRepairCost;
    public int TowerUpgradeCost;

    public TowerData(GameObject tower)
    {
        TowerType = tower.name.Substring(0, tower.name.IndexOf('('));
        //Debug.Log(TowerType);
        TowerLevel = tower.GetComponent<ShopData>().level;
        TowerHealth = tower.GetComponent<Health>().currentHealth;
        TowerRepairCost = tower.GetComponent<ShopData>().repairCost;
        TowerUpgradeCost = tower.GetComponent<ShopData>().upgradeCost;
        
        TowerPos = new float[3];
        TowerPos[0] = tower.transform.position.x;
        TowerPos[1] = tower.transform.position.y;
        TowerPos[2] = tower.transform.position.z;
    }
}
