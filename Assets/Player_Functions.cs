using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Functions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetHit(float damage)
    {
        GetComponent<Player_Components>().currentHitpoints -= damage;
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


    private void Die()
    {

    }
}
