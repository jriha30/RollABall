using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power_Script : MonoBehaviour
{
    public GameObject player;
    private Rigidbody rb;
    private Player_Components pc;

    public float dashForce = 100;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        rb = player.GetComponent<Rigidbody>();
        pc = player.GetComponent<Player_Components>();
    }

    public void Activate()
    {
        if(name == "POWER_Dash" && pc.currentMagic >= pc.maxMagic)
        {
            rb.AddForce(player.transform.forward * dashForce, ForceMode.VelocityChange);
            pc.currentMagic -= pc.maxMagic;
        }
        else if(name == "POWER_Heal" && pc.currentMagic >= pc.maxMagic / 2)
        {
            pc.currentHitpoints += pc.maxHitpoints / 10;
            pc.currentMagic -= pc.maxMagic / 2;
        }
        else if(name == "POWER_Stamina" && pc.currentMagic >= pc.maxMagic / 3)
        {
            pc.currentStamina += pc.maxStamina / 5;
            pc.currentMagic -= pc.maxMagic / 3;
        }
    }
}
