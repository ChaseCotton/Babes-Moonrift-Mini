using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGen : MonoBehaviour
{
    // code generates map on start 

    public GameObject MapTile;

    [SerializeField]private int mapWidth;
    [SerializeField] private int mapHeight;

    public static List<GameObject> mapTiles = new List<GameObject>();
    public static List<GameObject> pathTiles = new List<GameObject>();

    public static GameObject startTile;
    public static GameObject endTile;

    private GameObject currentTile;
    private int currentIndex;
    private int nextIndex; 

    public Color pathColor;

    public Color startColor;
    public Color endColor;


    private void Awake()
    {
        generateMap();
    }

    private List<GameObject> getTopEdgeTiles()
    {
        List<GameObject> edgeTiles = new List<GameObject>();

        for (int i = mapWidth * (mapHeight - 1);i < mapWidth * mapHeight; i++)
        {
            edgeTiles.Add(mapTiles[i]);
        }

        return edgeTiles;
    }

    private List<GameObject> getBottomEdgeTiles()
    {
        List<GameObject> edgeTiles = new List<GameObject>();

        for (int i = 0; i < mapWidth; i++)
        {
            edgeTiles.Add(mapTiles[i]);
        }

        return edgeTiles;
    }

    private void moveUp()
    {
        pathTiles.Add(currentTile);
        currentIndex = mapTiles.IndexOf(currentTile);
        nextIndex = currentIndex + mapWidth;
        currentTile = mapTiles[nextIndex];
    }

    private void moveDown()
    {
        pathTiles.Add(currentTile);
        currentIndex = mapTiles.IndexOf(currentTile);
        nextIndex = currentIndex - mapWidth;
        currentTile = mapTiles[nextIndex];
    }

    private void moveLeft()
    {
        pathTiles.Add(currentTile);
        currentIndex = mapTiles.IndexOf(currentTile);
        nextIndex = currentIndex - 1;
        currentTile = mapTiles[nextIndex];
    }

    private void moveRight()
    {
        pathTiles.Add(currentTile);
        currentIndex = mapTiles.IndexOf(currentTile);
        nextIndex = currentIndex + 1;
        currentTile = mapTiles[nextIndex];
    }

    private void generateMap()
    {
        for (int y = - 5; y < mapHeight - 5; y++)
        {
            for (int x = - 5; x < mapWidth - 5; x++)
            {
                GameObject newTile = Instantiate(MapTile);

                mapTiles.Add(newTile);

                newTile.transform.position = new Vector2(x, y);


            }
        }

        List<GameObject> topEdgeTiles = getTopEdgeTiles();
        List<GameObject> bottomEdgeTiles = getBottomEdgeTiles();

        // if dont want from top or bottom u can call mapTiles[#]
        startTile = topEdgeTiles[1];
        endTile = bottomEdgeTiles[7];

        currentTile = startTile;

        //need to build map builder into unity or keep hard coded idc

        for (int i = 0;i < 7; i++)
        {
            moveDown();
        }

        for (int i = 0;i < 3; i++)
        {
            moveRight();
        }

        for (int i = 0; i < 6; i++)
        {
            moveUp();
        }

        for (int i = 0; i < 3; i++)
        {
            moveRight();
        }

        for (int i = 0; i < 8; i++)
        {
            moveDown();
        }

        pathTiles.Add(endTile);

        foreach(GameObject obj in pathTiles)
        {
            obj.GetComponent<SpriteRenderer>().color = pathColor;
        }

        startTile.GetComponent<SpriteRenderer>().color = startColor;
        endTile.GetComponent<SpriteRenderer>().color = endColor;

    }

}
