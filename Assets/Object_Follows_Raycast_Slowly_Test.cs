using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Follows_Raycast_Slowly_Test : MonoBehaviour
{
    public GameObject bullet;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        bullet = Instantiate(bullet, new Vector3(0,2,0), Quaternion.identity);
        rb = bullet.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }
}
