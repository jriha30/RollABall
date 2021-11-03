using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private int direction = 1;

    private Vector3 relativePlayerPos;

    private void OnTriggerEnter(Collider player)
    {
        //print(player.transform.position);
        SetDirection(player);
        if (transform.name == "Door1")
            ChangeLocations(player, transform.parent.Find("Door2"));
        else if (transform.name == "Door2")
            ChangeLocations(player, transform.parent.Find("Door1"));
        //print(player.transform.position);
    }

    private void SetDirection(Collider player)
    {
        if (player.transform.position.z < transform.position.z)
        {
            direction = 1;
        }
        else if (player.transform.position.z > transform.position.z)
        {
            direction = -1;
        }
    }

    private void ChangeLocations(Collider player, Transform newLocation)
    {
        relativePlayerPos = transform.position - player.transform.position;
        Vector3 newPlayerPos = newLocation.position - relativePlayerPos;
        player.transform.position = newPlayerPos + new Vector3(0f,0f,.5f * direction);
    }
}