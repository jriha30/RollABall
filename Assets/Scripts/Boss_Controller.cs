using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Controller : MonoBehaviour
{
    private Rigidbody rb;

    public bool shouldControl;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        shouldControl = false;
        //rb.AddForce(new Vector3(0, force, 0));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(gameObject.activeSelf)
        {
            ControlBoss();
        }
    }

    private void ControlBoss()
    {
        Vector3 force = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
        rb.AddForce(force, ForceMode.VelocityChange);
    }
}
