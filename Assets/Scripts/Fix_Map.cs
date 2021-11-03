using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fix_Map : MonoBehaviour
{
    private List<GameObject> listOfWalls;
    private List<GameObject> listOfDoorways;
    public List<GameObject> listOfNotDoorways;
    public List<GameObject> listOfOverlappingDoorways;
    public List<GameObject> listOfNotOverlappingDoorways;
    public List<GameObject> listOfRooms;

    public GameObject finalRoom;

    public playerController player;

    // Start is called before the first frame update
    void Start()
    {
        finalRoom = null;
        listOfRooms = GetComponent<Map_Components>().listOfRooms;
        listOfWalls = GetComponent<Map_Components>().listOfWalls;
        foreach(GameObject i in listOfWalls)
        {
            FindOverlappingDoors(i);
        }

        foreach(GameObject i in listOfNotOverlappingDoorways)
        {
            ReplaceNotOverlappingDoors(i);
        }
        //SetMapSize();
        SetFinalRoom();
    }

    private void SetMapSize()
    {
        float xScale = 0;
        float yScale = Random.Range(1f, 5f);
        float zScale = 0;
        while(xScale < 2f && zScale < 2f)
        {
            xScale = Random.Range(1f, 5f);
            zScale = Random.Range(1f, 5f);
        }
        transform.localScale = new Vector3(xScale, yScale, zScale);
    }

    private void SetFinalRoom()
    {
        List<GameObject> listNoStart = listOfRooms;
        listNoStart.Remove(listNoStart[0]);
        foreach (GameObject i in listNoStart)
        {
            if (finalRoom == null)
            {
                finalRoom = i;
            }
            else
            {
                if(GetAverageRoomSize(finalRoom) < GetAverageRoomSize(i))
                {
                    finalRoom = i;
                }
            }
        }
        finalRoom.name = "Boss Room";
        finalRoom.tag = "Ending Room";
    }

    private float GetAverageRoomSize(GameObject i)
    {
        return (i.transform.lossyScale.x + i.transform.lossyScale.z) / 2;
    }

    private void FindOverlappingDoors(GameObject currentDoor)
    {
        int count = 0;
        foreach(GameObject i in listOfWalls)
        {
            if(currentDoor.transform.position == i.transform.position)
            {
                count++;
            }
        }
        if(count > 1)
        {
            listOfOverlappingDoorways.Add(currentDoor);
        }
        else
        {
            listOfNotOverlappingDoorways.Add(currentDoor);
        }
    }

    private void ReplaceNotOverlappingDoors(GameObject doorway)
    {
        GameObject fullWall = Resources.Load<GameObject>("Prefabs/Wall");
        GameObject fullWallObject = Instantiate(fullWall, transform.position, Quaternion.identity);
        fullWallObject.transform.position = doorway.transform.position;
        fullWallObject.transform.rotation = doorway.transform.rotation;
        fullWallObject.transform.parent = doorway.transform.parent;
        fullWallObject.transform.localScale = doorway.transform.localScale;
        fullWallObject.transform.name = doorway.transform.name;
        doorway.transform.parent.GetComponent<Room_Components>();
        listOfNotDoorways.Add(fullWallObject);
        Destroy(doorway);
    }
}