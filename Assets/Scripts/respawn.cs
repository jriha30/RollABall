using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{
    private Rigidbody rb;
    public playerController player;
    public int height;

    public GameObject enemy_Manager;
    public GameObject room_Manager;
    public GameObject time_Manager;



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
            GameObject time = Instantiate(time_Manager);
            time.name = "Time_Manager";
            GameObject enemy = Instantiate(enemy_Manager);
            enemy.name = "Enemy_Manager";
            GameObject room = Instantiate(room_Manager);
            room.name = "Room_Manager";
        }
    }

    private void ClearArea()
    {
        if(transform.Find("Hub") != null)
        {
            Destroy(transform.Find("Hub"));
        }
        if (GameObject.Find("Enemy_Manager") != null)
        {
            Destroy(GameObject.Find("Enemy_Manager"));
        }
        if (GameObject.Find("Room_Manager") != null)
        {
            Destroy(GameObject.Find("Room_Manager"));
        }
        if (GameObject.Find("Time_Manager") != null)
        {
            Destroy(GameObject.Find("Time_Manager"));
        }
    }
}