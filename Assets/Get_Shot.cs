using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Get_Shot : MonoBehaviour
{
    public Vector3 startPoint;
    public Vector3 direction;
    public Vector3 endPoint;

    public float charge;
    public float speed;
    public float damage;

    public float whenToDestroy;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPoint;
        endPoint = startPoint + direction * 5;
        speed *= charge;
        damage *= charge;
        transform.localScale *= charge;
        Destroy(transform.gameObject, whenToDestroy);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            GameObject tempEnemy = collision.transform.gameObject;
            if(tempEnemy.GetComponent<Enemy_Functions>().Dodge(tempEnemy.GetComponent<Enemy_Components>().armorClass))
            {
                tempEnemy.GetComponent<Enemy_Functions>().GetHit(damage * charge);
            }
        }
        if (collision.transform.tag != "Player")
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
