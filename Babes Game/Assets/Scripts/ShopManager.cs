using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    // keeps track of tower costs in shop
    public GameObject Menu;

    public GameObject CanonHUD;
    public GameObject BasicHUD;
    public GameObject LightningHUD;
    public GameObject IceHUD;
    public GameObject WindHUD;
    public GameObject FireHUD;

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

    public void exitShop()
    {
        Menu.SetActive(false);
    }

    public void enterShop()
    {
        Menu.SetActive(true);
    }

    public void showCanon()
    {
        CanonHUD.SetActive(true);
        BasicHUD.SetActive(false);
        LightningHUD.SetActive(false);
        IceHUD.SetActive(false);
        WindHUD.SetActive(false);
        FireHUD.SetActive(false);
    }

    public void showBasic()
    {
        CanonHUD.SetActive(false);
        BasicHUD.SetActive(true);
        LightningHUD.SetActive(false);
        IceHUD.SetActive(false);
        WindHUD.SetActive(false);
        FireHUD.SetActive(false);
    }

    public void showLightning()
    {
        CanonHUD.SetActive(false);
        BasicHUD.SetActive(false);
        LightningHUD.SetActive(true);
        IceHUD.SetActive(false);
        WindHUD.SetActive(false);
        FireHUD.SetActive(false);
    }

    public void showIce()
    {
        CanonHUD.SetActive(false);
        BasicHUD.SetActive(false);
        LightningHUD.SetActive(false);
        IceHUD.SetActive(true);
        WindHUD.SetActive(false);
        FireHUD.SetActive(false);
    }

    public void showWind()
    {
        CanonHUD.SetActive(false);
        BasicHUD.SetActive(false);
        LightningHUD.SetActive(false);
        IceHUD.SetActive(false);
        WindHUD.SetActive(true);
        FireHUD.SetActive(false);
    }

    public void showFire()
    {
        CanonHUD.SetActive(false);
        BasicHUD.SetActive(false);
        LightningHUD.SetActive(false);
        IceHUD.SetActive(false);
        WindHUD.SetActive(false);
        FireHUD.SetActive(true);
    }

}
