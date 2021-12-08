using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Controller : MonoBehaviour
{
    public GameObject player;
    public GameObject projectile;
    private Rigidbody rb;

    public float frequency;

    public bool isShooting = false;

    public float shootClock = 0;
    public float whenToShoot = 0;

    public GameObject timer;

    public bool shouldControl;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        timer = GameObject.Find("Time_Manager");
        rb = GetComponent<Rigidbody>();
        shootClock = Time_Record.current_Time;
        whenToShoot = shootClock;
        shouldControl = false;
        //rb.AddForce(new Vector3(0, force, 0));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(gameObject.activeSelf)
        {
            //ControlBoss();
        }
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

    private void ControlBoss()
    {
        //Vector3 force = new Vector3(Random.Range(-3f, 3f), 0, Random.Range(-3f, 3f));
        //rb.AddForce(force, ForceMode.VelocityChange);
    }
}
