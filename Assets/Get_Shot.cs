using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Get_Shot : MonoBehaviour
{
    public Vector3 startPoint;
    public Vector3 direction;
    public Vector3 endPoint;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPoint;
        endPoint = startPoint + direction * 5;
        Destroy(transform.gameObject, 10f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag != "Player")
        Destroy(transform.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        transform.position += direction / 10 * speed;
    }
}
