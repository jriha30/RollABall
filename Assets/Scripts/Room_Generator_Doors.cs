using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_Generator_Doors : MonoBehaviour
{
    private GameObject floor;
    private GameObject northWall;
    private GameObject southWall;
    private GameObject eastWall;
    private GameObject westWall;


    private bool isNorthDoor;
    private bool isSouthDoor;
    private bool isEastDoor;
    private bool isWestDoor;

    public int doorNumber;

    public int test;

    float Get_Midpoint(float num1, float num2)
    {
        float tempNum = num1 + num2;
        return tempNum / 2;
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

    Vector3 equalizeWallThickness(GameObject wall, int transform)
    {
        Vector3 newScale = wall.transform.localScale;
        newScale.z /= transform;
        return newScale;
    }


    // Start is called before the first frame update
    void Start()
    {
        doorNumber = 0;
        floor = Resources.Load<GameObject>("Prefabs/Floor");
        GameObject floorObject = Instantiate(floor, transform.position, Quaternion.identity);
        floorObject.name = "Floor";
        floorObject.transform.parent = transform;

        int northRandom = Random.Range(0, 2);
        if(northRandom == 0)
        {
            northWall = Resources.Load<GameObject>("Prefabs/Wall");
            isNorthDoor = false;
        }
        else
        {
            northWall = Resources.Load<GameObject>("Prefabs/Doorway_Prefab");
            isNorthDoor = true;
        }
        GameObject northWallObject = Instantiate(northWall, transform.position + new Vector3(0f, 2.5f, 5f), Quaternion.identity);
        northWallObject.name = "North Wall";
        northWallObject.transform.parent = transform;

        int southRandom = Random.Range(0, 2);
        if (southRandom == 0)
        {
            southWall = Resources.Load<GameObject>("Prefabs/Wall");
            isSouthDoor = false;
        }
        else
        {
            southWall = Resources.Load<GameObject>("Prefabs/Doorway_Prefab");
            isSouthDoor = true;
        }
        GameObject southWallObject = Instantiate(southWall, transform.position + new Vector3(0f, 2.5f, -5f), Quaternion.identity);
        southWallObject.name = "South Wall";
        southWallObject.transform.parent = transform;

        int eastRandom = Random.Range(0, 2);
        if (eastRandom == 0)
        {
            eastWall = Resources.Load<GameObject>("Prefabs/Wall");
            isEastDoor = false;
        }
        else
        {
            eastWall = Resources.Load<GameObject>("Prefabs/Doorway_Prefab");
            isEastDoor = true;
        }
        GameObject eastWallObject = Instantiate(eastWall, transform.position + new Vector3(5f, 2.5f, 0f), Quaternion.identity);
        eastWallObject.name = "East Wall";
        eastWallObject.transform.Rotate(0f, 90f, 0f);
        eastWallObject.transform.parent = transform;

        int westRandom = Random.Range(0, 2);
        if (westRandom == 0)
        {
            westWall = Resources.Load<GameObject>("Prefabs/Wall");
            isWestDoor = false;
        }
        else
        {
            westWall = Resources.Load<GameObject>("Prefabs/Doorway_Prefab");
            isWestDoor = true;
        }
        GameObject westWallObject = Instantiate(westWall, transform.position + new Vector3(-5f, 2.5f, 0f), Quaternion.identity);
        westWallObject.name = "West Wall";
        westWallObject.transform.Rotate(0f, 90f, 0f);
        westWallObject.transform.parent = transform;

        transform.localScale = new Vector3(Random.Range(2, 5), 1f, Random.Range(2, 5));
        northWallObject.transform.localScale = equalizeWallThickness(northWallObject, (int)transform.localScale.z);
        southWallObject.transform.localScale = equalizeWallThickness(southWallObject, (int)transform.localScale.z);
        eastWallObject.transform.localScale = equalizeWallThickness(eastWallObject, (int)transform.localScale.x);
        westWallObject.transform.localScale = equalizeWallThickness(westWallObject, (int)transform.localScale.x);

        if(isNorthDoor)
        {
            equalizeDoorway(northWallObject);
            doorNumber += 1;
        }
        if (isSouthDoor)
        {
            equalizeDoorway(southWallObject);
            doorNumber += 1;
        }
        if (isEastDoor)
        {
            equalizeDoorway(eastWallObject);
            doorNumber += 1;
        }
        if (isWestDoor)
        {
            equalizeDoorway(westWallObject);
            doorNumber += 1;
        }
        //print(doorNumber);
    }
}