using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    // keeps track of tower costs in shop

    public MoneyManager moneyManager;

    public GameObject basicTowerPrefab;

    public int basicTowerCost;

    public int GetTowerCost(GameObject towerPrefab)
    {
        int cost = 0;

        if (towerPrefab = basicTowerPrefab)
        {
            cost = basicTowerCost;
        }
        return cost;
    }

    public void buyTower(GameObject towerPrefab)
    {
        moneyManager.removeMoney(GetTowerCost(towerPrefab));
    }

    public bool canBuyTower(GameObject towerPrefab)
    {
        int cost = GetTowerCost(towerPrefab);

        bool canBuy = false;

        if (moneyManager.getCurrentMoney() >= cost)
        {
            canBuy = true;
        }

        return canBuy;
    }
}
