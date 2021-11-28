using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish_Level : MonoBehaviour
{

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }


    void OnCollisionEnter(Collision collision)
    {
        if(!collision.gameObject.GetComponent<Get_Shot>())
        {
            // do nothing
        }
        else if(collision.gameObject.GetComponent<Get_Shot>().parent == player)
        {
            respawn.ClearArea();
        }
    }
}
