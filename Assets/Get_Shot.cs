using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Get_Shot : MonoBehaviour
{
    public Vector3 startPoint;
    public Vector3 direction;

    public float charge;
    public float speed;
    public float damage;

    public GameObject parent;

    public float whenToDestroy;

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
        if (collision.gameObject != parent && collision.transform.tag == "Enemy")
        {
            GameObject hitCharacter = collision.transform.gameObject;
            if(hitCharacter.GetComponent<Enemy_Functions>().Dodge(hitCharacter.GetComponent<Enemy_Components>().armorClass))
            {
                hitCharacter.GetComponent<Enemy_Functions>().GetHit(damage * charge);
            }
        }
        else if(collision.gameObject != parent && collision.transform.tag == "Player")
        {
            GameObject hitCharacter = collision.transform.gameObject;
            if (hitCharacter.GetComponent<Player_Functions>().Dodge(hitCharacter.GetComponent<Player_Components>().armorClass))
            {
                hitCharacter.GetComponent<Player_Functions>().GetHit(damage * charge);
            }
        }
        if (collision.gameObject != parent)
        Destroy(transform.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        transform.position += direction / 10 * speed * charge;
    }
}
