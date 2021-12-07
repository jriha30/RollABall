using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn_Fireball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 20);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -200)
        {
            Destroy(gameObject);
        }
    }
}
