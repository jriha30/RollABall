using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{
    private Rigidbody rb;
    public playerController player;
    public int height;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        height = -50;
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.position.y < height)
        {
            player.transform.position = new Vector3(0f, 0.5f, 0f);
            player.isSprinting = false;
        }
    }
}
