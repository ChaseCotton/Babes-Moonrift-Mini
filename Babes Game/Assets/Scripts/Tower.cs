using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // tower stats and such 
    // detects if enemy is within range then destroys closest enemy to tower

    [SerializeField] private float range;
    [SerializeField] private int damage;
    [SerializeField] private float timeTweenShot;

    private float nextTimeToShoot;

    public GameObject currentTarget;

    private void Start()
    {
        nextTimeToShoot = Time.time;
    }
    private void Update()
    {
        updateNearestEnemy();

        if (Time.time >= nextTimeToShoot)
        {
            if (currentTarget != null)
            {
                shoot();
                nextTimeToShoot = Time.time + timeTweenShot;
            }
        }
    }

    private void updateNearestEnemy()
    {
        GameObject currentNearestEnemy = null;

        float distance = Mathf.Infinity;

        foreach(GameObject enemy in EnemyList.enemyList)
        {
            float _distance = (transform.position - enemy.transform.position).magnitude;

            if (_distance < distance)
            {
                distance = _distance;
                currentNearestEnemy = enemy;
            }
        }

        if (distance <= range)
        {
            currentTarget = currentNearestEnemy;
        }
        else
        {
            currentTarget = null;
        }
    }

    protected virtual void shoot()
    {
        Enemy enemyScript = currentTarget.GetComponent<Enemy>();
        
        enemyScript.takeDamage(damage);
    }


}
