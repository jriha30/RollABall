using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GR_Enemy_Controller : MonoBehaviour
{
    public GameObject player;
    public GameObject projectile;
    private Rigidbody rb;

    public float frequency;

    public float speed;

    public Vector3 directionVector = Vector3.zero;

    public bool isShooting = false;

    public float shootClock = 0;
    public float whenToShoot = 0;

    public GameObject timer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        timer = GameObject.Find("Time_Manager");
        rb = GetComponent<Rigidbody>();
        shootClock = Time_Record.current_Time;
        whenToShoot = shootClock;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //GroundedRangedControl();
    }


    void Update()
    {
        if (!isShooting)
        {
            whenToShoot = timer.GetComponent<Timer_Functions>().TimeTest(Time_Record.current_Time, frequency);
            isShooting = true;
        }
        shootClock = Time_Record.newTime(shootClock);
        if (shootClock > whenToShoot)
        {
            Shoot();
        }
    }


    private void Shoot()
    {
        GameObject projectileObject = Instantiate(projectile, transform.position + new Vector3(0, 2, 0), Quaternion.identity);
        projectileObject.GetComponent<Rigidbody>().useGravity = false;
        projectileObject.GetComponent<Get_Shot>().startPoint = transform.position;
        projectileObject.GetComponent<Get_Shot>().direction = (player.transform.position - transform.position).normalized;
        projectileObject.GetComponent<Get_Shot>().parent = gameObject;
        projectileObject.GetComponent<Get_Shot>().charge = GetComponent<Enemy_Components>().charge;
        projectileObject.GetComponent<Get_Shot>().damage = GetComponent<Enemy_Components>().damage;
        isShooting = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            if (player.GetComponent<Player_Functions>().Dodge(player.GetComponent<Player_Components>().armorClass))
            {
                player.GetComponent<Player_Functions>().GetHit(GetComponent<Enemy_Components>().damage);
            }
            GetComponent<Enemy_Functions>().GetHit(1);
        }
    }

    private void GroundedRangedControl()
    {
        float rand = Random.Range(0f, 10f);
        if(rand >= 0 && rand < 1)
        {
            rb.AddForce(Vector3.forward * speed, ForceMode.VelocityChange);
        }
        else if (rand >= 1 && rand < 2)
        {
            rb.AddForce(Vector3.back * speed, ForceMode.VelocityChange);
        }
        else if (rand >= 2 && rand < 3)
        {
            rb.AddForce(Vector3.left * speed, ForceMode.VelocityChange);
        }
        else if (rand >= 3 && rand < 5)
        {
            rb.AddForce(Vector3.right * speed, ForceMode.VelocityChange);
        }
        else
        {
            return;
        }
    }
}
