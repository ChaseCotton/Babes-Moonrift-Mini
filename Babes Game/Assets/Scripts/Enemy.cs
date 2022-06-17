using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    PlayerHealth playerHealth;

    // enemy navigation along path tiles 
    // enemy stats

    public float enemyHealth;
    public float movementSpeed;
    public int enemyDamage = 1;
    private int coinReward;
    private int damage;

    private GameObject targetTile;

    private void Awake()
    {
        EnemyList.enemyList.Add(gameObject);
    }

    private void Start()
    {
        initializeEnemy();
    }

    private void Update()
    {
        checkPosition();
        moveEnemy();
        takeDamage(0);
    }

    private void initializeEnemy()
    {
        targetTile = MapGen.startTile;
    }

    public void takeDamage(float amount)
    {
        enemyHealth -= amount;

        if (enemyHealth <= 0)
        {
            die();
        }
    }

    private void die()
    {
        EnemyList.enemyList.Remove(gameObject);
        Destroy(transform.gameObject);
    }

    private void moveEnemy()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetTile.transform.position, movementSpeed * Time.deltaTime);
    }

    private void checkPosition()
    {
        if (targetTile != null && targetTile != MapGen.endTile)
        {
            float distance = (transform.position - targetTile.transform.position).magnitude;

            if (distance < 0.001f)
            {
                int currentIndex = MapGen.pathTiles.IndexOf(targetTile);

                targetTile = MapGen.pathTiles[currentIndex + 1];
            }
        }

        if (targetTile == MapGen.endTile)
        {
            float distanceEnd  = (transform.position - targetTile.transform.position).magnitude;

            if (distanceEnd < 0.001f)
            {
                playerHealth = FindObjectOfType<PlayerHealth>();
                playerHealth.damagePlayer(enemyDamage);
                die();
            }
        }
    }
}
