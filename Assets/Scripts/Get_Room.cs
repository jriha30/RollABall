using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Get_Room : MonoBehaviour
{
    public static GameObject currentRoom;
    public static GameObject previousRoom;

    private float time;

    private Vector3 down;

    void Start()
    {
        time = 0;
        down = transform.TransformDirection(Vector3.down * 2);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        previousRoom = currentRoom;
        time = Time_Record.newTime(time);
        if(time > .2)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, down, out hit))
            {
                if (hit.collider.name == "Floor")
                {
                    currentRoom = hit.collider.transform.parent.gameObject;
                    currentRoom.transform.parent.GetComponent<Map_Components>().roomOfPlayer = currentRoom;
                    GetComponent<Player_Components>().currentRoom = currentRoom;
                }
            }
            time = 0;
        }
        if(previousRoom != currentRoom)
        {
            if(previousRoom != null)
            previousRoom.GetComponent<Change_Self>().ClearEnemies();
            if (!currentRoom.GetComponent<Room_Components>().isCleared)
            {
                if(currentRoom.tag == "Ending Room")
                {
                    print("The boss has been summoned!");
                }
                currentRoom.GetComponent<Change_Self>().CloseDoors(Time_Record.current_Time);
            }
        }
    }
}