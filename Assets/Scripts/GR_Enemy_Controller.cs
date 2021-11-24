using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GR_Enemy_Controller : MonoBehaviour
{
    public GameObject player;
    public GameObject projectile;

    public float speed;

    public Vector3 directionVector = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GroundedRangedControl();
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
        if (Random.Range(0, 120) == 0)
        {
            GameObject projectileObject = Instantiate(projectile, transform.position + new Vector3(0, 2, 0), Quaternion.identity);
            projectileObject.GetComponent<Rigidbody>().useGravity = false;
            projectileObject.GetComponent<Get_Shot>().startPoint = transform.position;
            projectileObject.GetComponent<Get_Shot>().direction = (player.transform.position - transform.position).normalized;
            projectileObject.GetComponent<Get_Shot>().parent = gameObject;
            projectileObject.GetComponent<Get_Shot>().charge = Random.Range(.5f, 1.25f);
        }
    }
}
