using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Components : MonoBehaviour
{
    public GameObject currentRoom;
    public int maxHitpoints;
    public float currentHitpoints;
    private float tempHitpoints;

    public float armorClass;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentRoom = Get_Room.currentRoom;
        currentHitpoints = maxHitpoints;
    }
}
