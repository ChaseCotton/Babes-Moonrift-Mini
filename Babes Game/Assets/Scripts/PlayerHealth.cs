using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth;
    public int startingHealth = 100;

    void Start()
    {
        playerHealth = startingHealth;
    }

    public void damagePlayer(int damage)
    {
        playerHealth -= damage;
    }
}
