using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish_Level : MonoBehaviour
{

    public GameObject player;

    public Set_Text text;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        text = GameObject.Find("Canvas").GetComponent<Set_Text>();
    }


    void OnCollisionEnter(Collision collision)
    {
        if(!collision.gameObject.GetComponent<Get_Shot>())
        {
            // do nothing
        }
        else if(collision.gameObject.GetComponent<Get_Shot>().parent == player)
        {
            text.ResetText();
            respawn.ClearArea();
        }
    }
}
