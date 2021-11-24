using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FM_Enemy_Controller : MonoBehaviour
{
    public GameObject player;

    public float speed;

    public float force;

    public Vector3 directionToGo;

    public bool shouldMove = false;


    public float delay;
    private float startTime;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        startTime = Time_Record.current_Time + delay;
    }

    private void Update()
    {
        if(!shouldMove && Time_Record.current_Time >= startTime)
        {
            shouldMove = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(shouldMove)
        FlyingMeleeControl();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            player.GetComponent<Rigidbody>().AddForce(directionToGo * force, ForceMode.VelocityChange);
            if (player.GetComponent<Player_Functions>().Dodge(player.GetComponent<Player_Components>().armorClass))
            {
                player.GetComponent<Player_Functions>().GetHit(GetComponent<Enemy_Components>().damage);
            }
            GetComponent<Enemy_Functions>().GetHit(1);
        }
    }

    private void FlyingMeleeControl()
    {
        directionToGo = (player.transform.position - transform.position).normalized;
        transform.position += directionToGo / 10 * speed;
    }
}
