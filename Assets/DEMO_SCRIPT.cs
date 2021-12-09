using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEMO_SCRIPT : MonoBehaviour
{
    public GameObject map;
    public GameObject smallMap;
    private Rigidbody rb;
    public GameObject mainCamera;
    public Hub_Decorator hd;
    public Player_Components pc;

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject bossEnemy;


    // Start is called before the first frame update
    void Start()
    {
        rb = GameObject.Find("Player").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Instantiate(map, new Vector3(0, -1000, 0), Quaternion.identity);
        }
        else if (Input.GetKeyDown(KeyCode.O))
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
        else if (Input.GetKeyDown(KeyCode.I))
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
            RaycastHit hit;

            if (Physics.Raycast(mainCamera.transform.position + mainCamera.transform.forward, mainCamera.transform.forward, out hit,10))
            {
                Destroy(hit.collider.gameObject);
            }
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Instantiate(smallMap, new Vector3(0, -1000, 0), Quaternion.identity);
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            pc.currentHitpoints = 0;
            pc.transform.position = Vector3.zero;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.useGravity = true;
        }
        else if(Input.GetKeyDown(KeyCode.Keypad1))
        {
            Instantiate(enemy1, pc.transform.position + pc.transform.forward * 5, Quaternion.identity);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            Instantiate(enemy2, pc.transform.position + pc.transform.forward * 5, Quaternion.identity);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            Instantiate(enemy3, pc.transform.position + pc.transform.forward * 5, Quaternion.identity);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            Instantiate(enemy4, pc.transform.position + pc.transform.forward * 5, Quaternion.identity);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            Instantiate(bossEnemy, pc.transform.position + pc.transform.forward * 5, Quaternion.identity);
        }
    }
}
