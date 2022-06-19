using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    // kees track player money

    public int currentPlayerMoney;

    public int starterMoney;

    public TextMeshProUGUI moneyText;

    public void Start()
    {
        currentPlayerMoney = starterMoney;
    }

    public void Update()
    {
        moneyText.text = currentPlayerMoney.ToString();
    }
    public int getCurrentMoney()
    {
        return currentPlayerMoney;
    }

    public void AddMoney(int amount)
    {
        currentPlayerMoney += amount;
    }

    public void removeMoney(int amount)
    {
        currentPlayerMoney -= amount;
    }


}
