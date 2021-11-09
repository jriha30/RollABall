using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    public GameObject player;

    private int frDirection = 1;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "Enemy FM")
        {
        }
        else if(gameObject.name == "Enemy FR")
        {
        }
    }




}
