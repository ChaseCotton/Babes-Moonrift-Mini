using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacing : MonoBehaviour
{
    // checks and places turrets

    public ShopManager shopManager;

    public MouseSettings mouse;

    public Camera cam;

    public LayerMask mask;
    public LayerMask towerMask;

    public GameObject basicTowerObject;

    private GameObject currentTowerPlacing;

    public bool isBuilding;

    private GameObject dummyPlacement;

    private GameObject hoverTile;

    public void Update()
    {
        // bug when hitting buy button twice without placing 

        if (isBuilding == true)
        {

            if (dummyPlacement != null)
            {
                currentHoverTile();

                if (hoverTile != null)
                {
                    dummyPlacement.transform.position = hoverTile.transform.position;
                }
            }

            if (Input.GetButtonDown("Fire1"))
            {
                placeBuilding();
            }
        }
    }

    public Vector2 GetMousePosition()
    {
        return cam.ScreenToWorldPoint(Input.mousePosition);
    }

    public void currentHoverTile()
    {
        Vector2 mousePosition = GetMousePosition();

        RaycastHit2D hit = Physics2D.Raycast(mousePosition, new Vector2(0, 0), 0.1f, mask, -100, 100);

        if (hit.collider != null)
        {
            if (MapGen.mapTiles.Contains(hit.collider.gameObject))
            {
                if (!MapGen.pathTiles.Contains(hit.collider.gameObject))
                {
                    hoverTile = hit.collider.gameObject;
                }
            }
        }
    }

    public bool checkForTower()
    {
        bool towerOnSlot = false;

        Vector2 mousePosition = GetMousePosition();

        RaycastHit2D hit = Physics2D.Raycast(mousePosition, new Vector2(0, 0), 0.1f, towerMask, -100, 100);

        if (hit.collider != null) // need to change this so that the ui buttons have colliders of some sort because currently thinks button counts as open tile
        {
            towerOnSlot = true;
        }

        return towerOnSlot;

    }

    public void placeBuilding()
    {
        if (hoverTile != null)
        {
            if (!checkForTower())
            {
                if (shopManager.canBuyTower(currentTowerPlacing) == true)
                {
                    GameObject newTowerObject = Instantiate(currentTowerPlacing);
                    newTowerObject.layer = LayerMask.NameToLayer("Tower");
                    newTowerObject.transform.position = hoverTile.transform.position;

                    endBuidling();
                    shopManager.buyTower(basicTowerObject);
                }
                else
                {
                    Debug.Log("Not Enough Money");
                }
            }
        }
    }

    public void startBuidling(GameObject towerToBuild)
    {
        isBuilding = true;

        

        currentTowerPlacing = towerToBuild;
        dummyPlacement = Instantiate(currentTowerPlacing);

        if (dummyPlacement.GetComponent<Tower>() != null)
        {
            Destroy(dummyPlacement.GetComponent<Tower>());
        }

        if (dummyPlacement.GetComponent<BarrelRotation>() != null) 
        {
            Destroy(dummyPlacement.GetComponent<BarrelRotation>());
        }
    }

    public void endBuidling()
    {
        isBuilding = false;

        if (dummyPlacement != null)
        {
            Destroy(dummyPlacement);
        }
    }

}
