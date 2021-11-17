using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Components : MonoBehaviour
{
    public GameObject initialRoom;

    public GameObject roomOfPlayer;

    public int totalDoorNumber = 0;
    public int numberOfRooms;

    public List<GameObject> listOfWalls;

    public List<GameObject> listOfSingleDoorways;

    public List<GameObject> listOfRooms;




    // Start is called before the first frame update
    void Start()
    {
        initialRoom = GetComponent<Map_Generator>().initialRoom;
        totalDoorNumber = GetComponent<Map_Generator>().totalDoorNumber;
        listOfRooms = GetComponent<Map_Generator>().listOfRooms;
        //listOfRooms.Insert(1, initialRoom);
        listOfWalls = GetComponent<Map_Generator>().listOfWalls;
    }


    public void FindOutsideDoorways(GameObject currentDoorway, List<GameObject> listOfDoorways)
    {
        List<GameObject> tempList = new List<GameObject>();

        foreach(GameObject i in listOfDoorways)
        {
            if(i != currentDoorway)
            {
                tempList.Add(i);
            }
        }

        foreach(GameObject i in tempList)
        {
            if(i.transform.position != currentDoorway.transform.position)
            {
                i.GetComponent<Doorway_Components>().doorway.GetComponent<MeshRenderer>().enabled = true;
            }
        }
    }
}
