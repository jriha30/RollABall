using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FR_Enemy_Controller : MonoBehaviour
{
    public GameObject player;

    public int upDownDirection;

    public float speed;


    public float distance;

    private float upperBound;
    private float lowerBound;


    public GameObject projectile;


    // Start is called before the first frame update
    void Start()
    {
        upDownDirection = Random.Range(0, 1);
        if (upDownDirection == 0)
            upDownDirection = -1;
        speed = Random.Range(.2f, 1);
        player = GameObject.Find("Player");
        distance = Random.Range(2f, 10f);
        upperBound = transform.position.y + distance;
        lowerBound = transform.position.y - distance;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FlyingRangedControl();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Floor" || collision.gameObject.name == "Ceiling")
        {
            ChangeDirection();
        }
        else if(collision.gameObject == player)
        {
            if(player.GetComponent<Player_Functions>().Dodge(player.GetComponent<Player_Components>().armorClass))
            {
                player.GetComponent<Player_Functions>().GetHit(GetComponent<Enemy_Components>().damage);
            }
            GetComponent<Enemy_Functions>().GetHit(1);
        }
    }


    private void FlyingRangedControl()
    {
        if (transform.position.y > upperBound)
        {
            upDownDirection = -1;
        }
        else if(transform.position.y < lowerBound)
        {
            upDownDirection = 1;
        }
        if(upDownDirection == 1)
        {
            Move(new Vector3(0, .1f * speed, 0));
        }
        else if(upDownDirection == -1)
        {
            Move(new Vector3(0, -.1f * speed, 0));
        }
        if(Random.Range(0,120) == 0)
        {
            GameObject projectileObject = Instantiate(projectile, transform.position + new Vector3(0, 2, 0), Quaternion.identity);
            projectileObject.GetComponent<Rigidbody>().useGravity = false;
            projectileObject.GetComponent<Get_Shot>().startPoint = transform.position;
            projectileObject.GetComponent<Get_Shot>().direction = (player.transform.position - transform.position).normalized;
            projectileObject.GetComponent<Get_Shot>().parent = gameObject;
            projectileObject.GetComponent<Get_Shot>().charge = Random.Range(.5f, 1.25f);
        }
    }

    private void ChangeDirection()
    {
        if (upDownDirection == -1)
        {
            upDownDirection = 1;
        }
        else if (upDownDirection == 1)
        {
            upDownDirection = -1;
        }
    }

    private void Move(Vector3 direction)
    {
        transform.position += direction;
    }
}
