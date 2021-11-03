using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Components : MonoBehaviour
{
    public GameObject currentRoom;


    // Start is called before the first frame update
    void Start()
    {
        currentRoom = Get_Room.currentRoom;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
