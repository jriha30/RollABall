using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Components : MonoBehaviour
{
    public GameObject currentRoom;
    public int maxHitpoints;
    public float currentHitpoints;

    public float armorClass;

    // Start is called before the first frame update
    void Start()
    {
        currentRoom = Get_Room.currentRoom;
        currentHitpoints = maxHitpoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
