using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{
    private Rigidbody rb;
    public playerController player;
    public int height;

    public GameObject Manager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.position.y < height)
        {
            player.transform.position = new Vector3(0f, 0.5f, 0f);
            player.isSprinting = false;
            ClearArea();
            GameObject manager_object = Instantiate(Manager);
            manager_object.name = "Manager_Manager";
        }
    }

    public static void ClearArea()
    {
        if(GameObject.Find("Hub") != null)
        {
            Destroy(GameObject.Find("Hub"));
        }
        if (GameObject.Find("Manager_Manager") != null)
        {
            Destroy(GameObject.Find("Manager_Manager"));
        }
    }
}