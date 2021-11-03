using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Generator : MonoBehaviour
{
    public GameObject test1;
    public GameObject test2;


    [HideInInspector]
    public List<GameObject> listOfRooms;

    [HideInInspector]
    public List<GameObject> listOfWalls;

    private GameObject roomPrefab;

    //private GameObject currRoom;
    [HideInInspector]
    public GameObject initialRoom;
    [HideInInspector]
    public GameObject finalRoom;

    [HideInInspector]
    public int totalDoorNumber = 0;

    [HideInInspector]
    public int numberOfRooms;

    public int roomsToAdd;

    private int roomNumberCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(roomsToAdd == 0)
        {
            roomsToAdd = Random.Range(10, 20);
        }
        roomPrefab = Resources.Load<GameObject>("Prefabs/Empty_Room_Prefab");
        initialRoom = InstantiateRoom(new Vector3(0, 0, 0), "Starting Room");
        initialRoom.GetComponent<Rectangle_Room_Generator>().SetValues(5, 5);
        //initialRoom.GetComponent<Rectangle_Room_Generator>().ScaleWalls();
        initialRoom.tag = "Starting Room";
        initialRoom.GetComponent<Room_Components>().isCleared = true;
        AddToLists(initialRoom);
        finalRoom = initialRoom;
        while(roomNumberCounter != roomsToAdd)
        {
            GameObject roomChoice = listOfRooms[Random.Range(0, listOfRooms.Count)];
            string directionChoice = GetDirection();
            if(CheckIfRoomPossible(roomChoice,directionChoice))
            {
                CreateAdjacentRoom(roomChoice, directionChoice);
                roomNumberCounter += 1;
            }
        }
        //while(finalRoom == initialRoom)
        //{
        //    finalRoom = listOfRooms[Random.Range(0, listOfRooms.Count)];
        //}
        //finalRoom.name = "Boss Room";
        //finalRoom.tag = "Ending Room";
    }


    private string GetDirection()
    {
        int number = Random.Range(0, 5);
        if (number == 0 || number == 1)
            return "North";
        else if (number == 2)
            return "South";
        else if (number == 3)
            return "East";
        else
            return "West";
    }

    private bool CheckIfRoomPossible(GameObject room, string direction)
    {
        if (direction == "North")
        {
            if(!room.GetComponent<Room_Components>().isNorthConnected)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if(direction == "South")
        {
            if(!room.GetComponent<Room_Components>().isSouthConnected)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if(direction == "East")
        {
            if(!room.GetComponent<Room_Components>().isEastConnected)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if(direction == "West")
        {
            if(!room.GetComponent<Room_Components>().isWestConnected)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }



    private GameObject InstantiateRoom(Vector3 position, string roomName="Room")
    {
        GameObject roomClone = Instantiate(roomPrefab, position, Quaternion.identity);
        roomClone.name = roomName;
        roomClone.transform.parent = transform;
        //totalDoorNumber += roomClone.GetComponent<Rectangle_Room_Generator>().doorNumber;
        return roomClone;
    }

    private void SetValues()
    {
        numberOfRooms = listOfRooms.Count;
        foreach(GameObject i in listOfRooms)
        {
            totalDoorNumber += i.GetComponent<Rectangle_Room_Generator>().doorNumber;
        }
    }

    private void CreateAdjacentRoom(GameObject parentRoom, string direction)
    {
        Rectangle_Room_Generator parentClone = parentRoom.GetComponent<Rectangle_Room_Generator>();
        Room_Components parentCloneComponents = parentRoom.GetComponent<Room_Components>();
        GameObject createdRoom = null;

        bool isConnected1 = false;
        bool isConnected2 = false; ;

        if(direction == "North")
        {
            createdRoom = CreateAdjacentRoomsInstantiater(parentClone.northWallObject.transform);
            parentRoom.GetComponent<Room_Components>().isNorthConnected = true;
            createdRoom.GetComponent<Room_Components>().isSouthConnected = true;
            isConnected1 = parentRoom.GetComponent<Room_Components>().isNorthConnected;
            isConnected2 = createdRoom.GetComponent<Room_Components>().isSouthConnected;
        }
        else if(direction == "South")
        {
            createdRoom = CreateAdjacentRoomsInstantiater(parentClone.southWallObject.transform);
            parentRoom.GetComponent<Room_Components>().isSouthConnected = true;
            createdRoom.GetComponent<Room_Components>().isNorthConnected = true;
            isConnected1 = parentRoom.GetComponent<Room_Components>().isSouthConnected;
            isConnected2 = createdRoom.GetComponent<Room_Components>().isNorthConnected;
        }
        else if(direction == "East")
        {
            createdRoom = CreateAdjacentRoomsInstantiater(parentClone.eastWallObject.transform);
            parentRoom.GetComponent<Room_Components>().isEastConnected = true;
            createdRoom.GetComponent<Room_Components>().isWestConnected = true;
            isConnected1 = parentRoom.GetComponent<Room_Components>().isEastConnected;
            isConnected2 = createdRoom.GetComponent<Room_Components>().isWestConnected;
        }
        else if(direction == "West")
        {
            createdRoom = CreateAdjacentRoomsInstantiater(parentClone.westWallObject.transform);
            parentRoom.GetComponent<Room_Components>().isWestConnected = true;
            createdRoom.GetComponent<Room_Components>().isEastConnected = true;
            isConnected1 = parentRoom.GetComponent<Room_Components>().isWestConnected;
            isConnected2 = createdRoom.GetComponent<Room_Components>().isEastConnected;
        }

        createdRoom.name = direction + " Room - " + parentRoom.name;
        CreateAdjacentRoomsPositioner(createdRoom, direction);
        Physics.SyncTransforms();
        bool destroyed = false;

        if (FindIfIntersecting(createdRoom, listOfRooms))
        {
            destroyed = DestroyRoom(createdRoom, isConnected1, isConnected2);
        }

        foreach (GameObject i in listOfRooms)
        {
            if(createdRoom.transform.position == i.transform.position)
            {
                destroyed = DestroyRoom(createdRoom, isConnected1, isConnected2);
            }
        }
        if(!destroyed)
        {
            AddToLists(createdRoom);
        }
    }

    private bool DestroyRoom(GameObject createdRoom, bool bool1, bool bool2)
    {
        Destroy(createdRoom);
        roomNumberCounter -= 1;
        bool1 = false;
        bool2 = false;
        return true;
    }

    private void CreateAdjacentRooms(GameObject parentRoom)
    {
        Rectangle_Room_Generator parentClone = parentRoom.GetComponent<Rectangle_Room_Generator>();
        Room_Components parentCloneComponents = parentRoom.GetComponent<Room_Components>();

        int northR = Random.Range(0, 5);
        int southR = Random.Range(0, 5);
        int eastR = Random.Range(0, 5);
        int westR = Random.Range(0, 5);

        print(northR);
        print(southR);
        print(eastR);
        print(westR);
        if (parentClone.isNorthDoor && !parentCloneComponents.isNorthConnected && northR > 0 && listOfRooms.Count < 10)
        {
            GameObject northRoom = CreateAdjacentRoomsInstantiater(parentClone.northWallObject.transform);
            northRoom.name = "North Room - " + parentRoom.name;
            parentRoom.GetComponent<Room_Components>().isNorthConnected = true;
            northRoom.GetComponent<Room_Components>().isSouthConnected = true;
            CreateAdjacentRoomsPositioner(northRoom, "north");
            CreateAdjacentRooms(northRoom);
        }
        if (parentClone.isSouthDoor && !parentCloneComponents.isSouthConnected && southR > 0 && listOfRooms.Count < 10)
        {
            GameObject southRoom = CreateAdjacentRoomsInstantiater(parentClone.southWallObject.transform);
            southRoom.name = "South Room - " + parentRoom.name;
            parentRoom.GetComponent<Room_Components>().isSouthConnected = true;
            southRoom.GetComponent<Room_Components>().isNorthConnected = true;
            CreateAdjacentRoomsPositioner(southRoom, "south");
            CreateAdjacentRooms(southRoom);
        }
        if (parentClone.isEastDoor && !parentCloneComponents.isEastConnected && eastR > 0 && listOfRooms.Count < 10)
        {
            GameObject eastRoom = CreateAdjacentRoomsInstantiater(parentClone.eastWallObject.transform);
            eastRoom.name = "East Room - " + parentRoom.name;
            parentRoom.GetComponent<Room_Components>().isEastConnected = true;
            eastRoom.GetComponent<Room_Components>().isWestConnected = true;
            CreateAdjacentRoomsPositioner(eastRoom, "east");
            CreateAdjacentRooms(eastRoom);
        }
        if (parentClone.isWestDoor && !parentCloneComponents.isWestConnected && westR > 0 && listOfRooms.Count < 10)
        {
            GameObject westRoom = CreateAdjacentRoomsInstantiater(parentClone.westWallObject.transform);
            westRoom.name = "West Room - " + parentRoom.name;
            parentRoom.GetComponent<Room_Components>().isWestConnected = true;
            westRoom.GetComponent<Room_Components>().isEastConnected = true;
            CreateAdjacentRoomsPositioner(westRoom, "west");
            CreateAdjacentRooms(westRoom);
        }
    }

    private void AddToLists(GameObject roomClone)
    {
        listOfRooms.Add(roomClone);
        foreach (GameObject i in roomClone.GetComponent<Room_Components>().listOfWalls)
        {
            listOfWalls.Add(i);
        }
    }


    private GameObject CreateAdjacentRoomsInstantiater(Transform wallTransform)
    {
        GameObject newRoom = InstantiateRoom(new Vector3(wallTransform.position.x, 0, wallTransform.position.z));
        return newRoom;
    }

    private void CreateAdjacentRoomsPositioner(GameObject room, string direction)
    {
        if(direction == "North")
        {
            room.transform.position += new Vector3(0, 0, (room.transform.lossyScale.z * 10 / 2));
        }
        else if (direction == "South")
        {
            room.transform.position += new Vector3(0, 0, -(room.transform.lossyScale.z * 10 / 2));
        }
        else if (direction == "East")
        {
            room.transform.position += new Vector3((room.transform.lossyScale.x * 10 / 2), 0, 0);
        }
        else if (direction == "West")
        {
            room.transform.position += new Vector3(-(room.transform.lossyScale.x * 10 / 2), 0, 0);
        }
    }

    private bool FindIfIntersecting(GameObject toTest, List<GameObject> listOfRooms)
    {
        foreach(GameObject i in listOfRooms)
        {
            if (toTest.GetComponent<Room_Components>().floor.GetComponent<BoxCollider>().bounds.Intersects(i.GetComponent<Room_Components>().floor.GetComponent<BoxCollider>().bounds))
            {
                return true;
            }
        }
        return false;
    }

    //void Update()
    //{
    //    if(test1.GetComponent<BoxCollider>().bounds.Intersects(test2.GetComponent<BoxCollider>().bounds))
    //    {
    //        print("PROBLEM FOUND");
    //    }
    //}
}