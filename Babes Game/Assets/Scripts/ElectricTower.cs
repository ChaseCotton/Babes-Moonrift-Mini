using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricTower : Tower
{
    //basic tower class

    public GameObject bullet;
    public Transform barrel;
    public GameObject pivot;

    protected override void shoot()
    {
        base.shoot();

        GameObject newBullet = Instantiate(bullet, barrel.position, pivot.transform.rotation);
        newBullet.transform.position = barrel.position;
    }
}
