using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Self : MonoBehaviour
{
    public float whenToOpenDoors;
    public bool isDoorsClosed;

    // Start is called before the first frame update
    void Start()
    {
        whenToOpenDoors = -1;
    }

    // Update is called once per frame
    void Update()
    {


        if (whenToOpenDoors != -1 && isDoorsClosed && GetComponent<Room_Components>().numberOfEnemies == 0 && GetComponent<Room_Components>().listOfEnemies.Count == 0)
        {
            if (Time_Record.current_Time > whenToOpenDoors)
            {
                OpenDoors();
                whenToOpenDoors = -1;
                isDoorsClosed = false;
            }
        }
    }
    
    public void CloseDoors(float startingTime)
    {
        whenToOpenDoors = startingTime + 5;
        isDoorsClosed = true;
        foreach (GameObject i in GetComponent<Room_Components>().listOfWalls)
        {
            if(i != null)
                i.GetComponent<Change_Door>().CloseDoor();
        }
    }

    public void OpenDoors()
    {
        foreach (GameObject i in GetComponent<Room_Components>().listOfWalls)
        {
            if (i != null)
                i.GetComponent<Change_Door>().OpenDoor();
        }
        GetComponent<Room_Components>().isCleared = true;
    }


    public void ClearEnemies()
    {
        foreach(GameObject i in GetComponent<Room_Components>().listOfEnemies)
        {
            Destroy(i);
        }
        GetComponent<Room_Components>().listOfEnemies.Clear();
    }
}
