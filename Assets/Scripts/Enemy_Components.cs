using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Components : MonoBehaviour
{
    public GameObject whichRoom;
    public int maxHitpoints;
    public float currentHitpoints;

    public float armorClass;

    public float damage;
    public float charge;

    // Start is called before the first frame update
    void Start()
    {
        currentHitpoints = maxHitpoints;
    }

    public void ResetBoss()
    {
        currentHitpoints = maxHitpoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
