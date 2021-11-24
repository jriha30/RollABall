using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Controller : MonoBehaviour
{
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.AddForce(new Vector3(0, force, 0));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 force = new Vector3(Random.Range(-1, 1), 0, Random.Range(-1, 1));
        rb.AddForce(force, ForceMode.VelocityChange);
    }
}
