using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class Get_Shot : MonoBehaviour
{
    public Vector3 startPoint;
    public Vector3 direction;

    public float charge;
    public float speed;
    public float damage;

    public GameObject parent;

    public float whenToDestroy;

    public bool HitTarget = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPoint;
        speed *= charge;
        damage *= charge;
        transform.localScale *= charge;
        Destroy(transform.gameObject, whenToDestroy);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == parent)
        {
            return;
        }
        if (collision.transform.tag == "Enemy" && parent.tag != "Enemy")
        {
            GameObject hitCharacter = collision.transform.gameObject;
            if (hitCharacter.GetComponent<Enemy_Functions>().Dodge(hitCharacter.GetComponent<Enemy_Components>().armorClass))
            {
                hitCharacter.GetComponent<Enemy_Functions>().GetHit(damage);
            }
        }
        else if (collision.transform.tag == "Player" && parent.tag != "Player")
        {
            GameObject hitCharacter = collision.transform.gameObject;
            if (hitCharacter.GetComponent<Player_Functions>().Dodge(hitCharacter.GetComponent<Player_Components>().armorClass))
            {
                hitCharacter.GetComponent<Player_Functions>().GetHit(damage);
            }
        }
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(parent == null)
        {
            Destroy(gameObject);
        }
    }
    void FixedUpdate()
    {
        transform.position += direction / 10 * speed * charge;
    }
}
