using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTING_SCRIPT : MonoBehaviour
{
    public Transform playerCamera;
    public GameObject sphere;
    private Rigidbody rb;
    public float dashForce;

    public GameObject map;

    // Start is called before the first frame update
    void Start()
    {
        sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.GetComponent<SphereCollider>().enabled = false;
        sphere.GetComponent<MeshRenderer>().enabled = false;
        sphere.transform.parent = transform;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Instantiate(map, new Vector3(0, Random.Range(-1000f,1000f), 0), Quaternion.identity);
        }
        Debug.DrawRay(playerCamera.position, playerCamera.forward * 10);
        sphere.transform.position = (playerCamera.forward * 10) + playerCamera.position;
        if(Input.GetMouseButtonDown(1))
        {
            rb.AddForce(transform.forward * dashForce,ForceMode.VelocityChange);
        }
        //Vector2 mouseRotation = Input.mouseScrollDelta;
        //if (mouseRotation.y < 0)
        //{
        //    print("Down");
        //}
        //else if (mouseRotation.y > 0)
        //{
        //    print("Up");
        //}
    }
}