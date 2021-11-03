using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rectangle_Room_Generator : MonoBehaviour
{
    private GameObject floor;
    private GameObject northWall;
    private GameObject southWall;
    private GameObject eastWall;
    private GameObject westWall;

    [HideInInspector]
    public GameObject floorObject;
    [HideInInspector]
    public GameObject northWallObject;
    [HideInInspector]
    public GameObject southWallObject;
    [HideInInspector]
    public GameObject eastWallObject;
    [HideInInspector]
    public GameObject westWallObject;

    [HideInInspector]
    public bool isNorthDoor;
    [HideInInspector]
    public bool isSouthDoor;
    [HideInInspector]
    public bool isEastDoor;
    [HideInInspector]
    public bool isWestDoor;

    [HideInInspector]
    public int doorNumber;

    public int xScale;
    public int zScale;

    // Start is called before the first frame update
    void Awake()
    {
        SetValues();
        doorNumber = 0;
        CreateRoom();
    }

    public void CreateRoom()
    {
        InstantiateFloor();
        InstantiateWalls();
        ScaleWalls();
        EqualizeDoorways();
    }

    public void SetValues(int x=-1, int z=-1)
    {
        if (x == -1)
            xScale = Random.Range(2, 10);
        else
            xScale = x;
        if (z == -1)
            zScale = Random.Range(2, 10);
        else
            zScale = z;
    }

    float Get_Midpoint(float num1, float num2)
    {
        float tempNum = num1 + num2;
        return tempNum / 2;
    }

    Vector3 equalizeWallThickness(GameObject wall, int transform)
    {
        Vector3 newScale = wall.transform.localScale;
        newScale.z /= transform;
        return newScale;
    }

    void equalizeDoorway(GameObject doorwayWall)
    {
        Transform leftWall = doorwayWall.transform.Find("Wall (Left)");
        Transform rightWall = doorwayWall.transform.Find("Wall (Right)");
        Transform doorway = doorwayWall.transform.Find("Doorway");

        float doorwayScaleValue = doorwayWall.transform.lossyScale.x / 10;

        // Scales doorway correctly!
        Vector3 temp = doorway.localScale;
        temp.x /= doorwayScaleValue;
        doorway.localScale = temp;
        // Scales doorway correctly!

        // Scales doorway walls!
        float halfWall = doorwayWall.transform.lossyScale.x / 2;
        float wallScale = (halfWall - 1.5f) / doorwayWall.transform.lossyScale.x;
        float wallPos = Get_Midpoint(1.5f, halfWall) / doorwayWall.transform.lossyScale.x;

        leftWall.transform.localPosition = new Vector3(-wallPos, leftWall.transform.localPosition.y, leftWall.transform.localPosition.z);
        rightWall.transform.localPosition = new Vector3(wallPos, rightWall.transform.localPosition.y, rightWall.transform.localPosition.z);
        leftWall.transform.localScale = new Vector3(wallScale, leftWall.transform.localScale.y, leftWall.transform.localScale.z);
        rightWall.transform.localScale = new Vector3(wallScale, rightWall.transform.localScale.y, rightWall.transform.localScale.z);
        // Scales doorway walls!
    }

    public void InstantiateFloor()
    {
        floor = Resources.Load<GameObject>("Prefabs/Floor");
        floorObject = Instantiate(floor, transform.position, Quaternion.identity);
        floorObject.name = "Floor";
        floorObject.transform.parent = transform;
    }

    public void InstantiateWalls()
    {
        northWall = Resources.Load<GameObject>("Prefabs/Doorway_Prefab");
        isNorthDoor = true;
        northWallObject = Instantiate(northWall, transform.position + new Vector3(0f, 2.5f, 5f), Quaternion.identity);
        northWallObject.name = "North Wall";
        northWallObject.transform.parent = transform;

        southWall = Resources.Load<GameObject>("Prefabs/Doorway_Prefab");
        isSouthDoor = true;
        southWallObject = Instantiate(southWall, transform.position + new Vector3(0f, 2.5f, -5f), Quaternion.identity);
        southWallObject.name = "South Wall";
        southWallObject.transform.parent = transform;

        eastWall = Resources.Load<GameObject>("Prefabs/Doorway_Prefab");
        isEastDoor = true;
        eastWallObject = Instantiate(eastWall, transform.position + new Vector3(5f, 2.5f, 0f), Quaternion.identity);
        eastWallObject.name = "East Wall";
        eastWallObject.transform.Rotate(0f, 90f, 0f);
        eastWallObject.transform.parent = transform;

        westWall = Resources.Load<GameObject>("Prefabs/Doorway_Prefab");
        isWestDoor = true;
        westWallObject = Instantiate(westWall, transform.position + new Vector3(-5f, 2.5f, 0f), Quaternion.identity);
        westWallObject.name = "West Wall";
        westWallObject.transform.Rotate(0f, 90f, 0f);
        westWallObject.transform.parent = transform;
    }

    public void ScaleWalls()
    {
        //if(xScale == -1)
        //xScale = Random.Range(2, 10);
        //if(zScale == -1)
        //zScale = Random.Range(2, 10);
        transform.localScale = new Vector3(xScale, 1f, zScale);
        northWallObject.transform.localScale = equalizeWallThickness(northWallObject, (int)transform.localScale.z);
        southWallObject.transform.localScale = equalizeWallThickness(southWallObject, (int)transform.localScale.z);
        eastWallObject.transform.localScale = equalizeWallThickness(eastWallObject, (int)transform.localScale.x);
        westWallObject.transform.localScale = equalizeWallThickness(westWallObject, (int)transform.localScale.x);
    }

    public void EqualizeDoorways()
    {
        equalizeDoorway(northWallObject);
        equalizeDoorway(southWallObject);
        equalizeDoorway(eastWallObject);
        equalizeDoorway(westWallObject);
    }
}