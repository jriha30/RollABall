using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEMO_SCRIPT : MonoBehaviour
{
    public GameObject map;
    private Rigidbody rb;
    public Hub_Decorator hd;
    public Player_Components pc;

    // Start is called before the first frame update
    void Start()
    {
        rb = GameObject.Find("Player").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Instantiate(map, new Vector3(0, -1000, 0), Quaternion.identity);
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            if (hd.enabled)
            {
                hd.enabled = false;
            }
            else
            {
                hd.enabled = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            if (rb.useGravity)
            {
                rb.useGravity = false;
            }
            else
            {
                rb.useGravity = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            Destroy(pc.currentRoom.GetComponent<Room_Components>().ceiling);
        }
    }
}
