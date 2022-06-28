using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth;
    public int startingHealth = 100;

    public TextMeshProUGUI healthText;

    public GameObject deathScreen;

    private bool playSound;

    void Start()
    {
        playerHealth = startingHealth;

        playSound = true;
    }

    public void Update()
    {
        healthText.text = playerHealth.ToString();

        if (playerDied())
        {
            playerDeath();
        }
    }
    public void damagePlayer(int damage)
    {
        playerHealth -= damage;
    }

    public bool playerDied()
    {
        if (playerHealth <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void playerDeath()
    {
        if (playSound is true)
        {
            SoundManager.PlaySound("lose");
            playSound = false;
        }
        playerHealth = 0;
        deathScreen.SetActive(true);
        Time.timeScale = 0f;
    }
}
