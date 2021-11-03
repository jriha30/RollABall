using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_Components : MonoBehaviour
{
    public bool isCleared;

    public int doorNumber = 0;
    //[HideInInspector]
    public List<GameObject> listOfWalls;

    //[HideInInspector]
    public GameObject floor;
    //[HideInInspector]
    public GameObject northWall;
    //[HideInInspector]
    public GameObject southWall;
    //[HideInInspector]
    public GameObject eastWall;
    //[HideInInspector]
    public GameObject westWall;

    public bool isPlayer = false;


    public bool isNorthConnected;
    public bool isSouthConnected;
    public bool isEastConnected;
    public bool isWestConnected;

    public List<GameObject> listOfEnemies;

    public int numberOfEnemies;
    public int minEnemies;
    public int maxEnemies;


    // Start is called before the first frame update
    void Awake()
    {
        isCleared = false;
        floor = GetComponent<Rectangle_Room_Generator>().floorObject;
        northWall = GetComponent<Rectangle_Room_Generator>().northWallObject;
        southWall = GetComponent<Rectangle_Room_Generator>().southWallObject;
        eastWall = GetComponent<Rectangle_Room_Generator>().eastWallObject;
        westWall = GetComponent<Rectangle_Room_Generator>().westWallObject;
        listOfWalls.Add(northWall);
        listOfWalls.Add(southWall);
        listOfWalls.Add(eastWall);
        listOfWalls.Add(westWall);
        GetDoorNumber();
        numberOfEnemies = Random.Range(minEnemies, maxEnemies);
    }

    void Update()
    {
        if(Get_Room.currentRoom == this.gameObject)
        {
            isPlayer = true;
        }
        else
        {
            isPlayer = false;
        }
    }

    public void GetDoorNumber()
    {
        foreach(GameObject i in listOfWalls)
        {
            if(i.GetComponent<Doorway_Components>().doorway.GetComponent<BoxCollider>().enabled == false)
            {
                doorNumber++;
            }
        }
    }
}
