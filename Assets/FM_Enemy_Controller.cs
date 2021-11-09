using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FM_Enemy_Controller : MonoBehaviour
{
    public GameObject player;

    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FlyingMeleeControl();
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


    private void FlyingMeleeControl()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 newEnemyPos = transform.position - playerPos;
        transform.position -= newEnemyPos / 100 * speed;
    }
}
