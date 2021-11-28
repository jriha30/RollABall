using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Functions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.gameObject.GetComponent<Enemy_Components>().currentHitpoints <= 0)
        {
            Die();
        }
    }

    public void GetHit(float damage)
    {
        GetComponent<Enemy_Components>().currentHitpoints -= damage;
    }

    public bool Dodge(float armorClass)
    {
        float hitNumber = Random.Range(1f, 20f);
        if (hitNumber <= armorClass)
        {
            print("Dodged");
            return false;
        }
        else
        {
            print("Hit!");
            return true;
        }
    }


    public void Die()
    {
        if(gameObject.name == "Boss")
        {
            Boss_Room.bossAlive = false;
            Boss_Room.bossEnemyFinalPosition = transform.position;
        }
        if(GetComponent<Enemy_Components>().whichRoom != null)
        GetComponent<Enemy_Components>().whichRoom.GetComponent<Room_Components>().listOfEnemies.Remove(transform.gameObject);
        Destroy(transform.gameObject);
    }
}
