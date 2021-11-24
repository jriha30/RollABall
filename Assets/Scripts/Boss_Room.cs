using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Room : MonoBehaviour
{
    public Room_Components components;

    public GameObject bossEnemy;

    // Start is called before the first frame update
    void Start()
    {
        components = GetComponent<Room_Components>();
        bossEnemy = Resources.Load<GameObject>("Prefabs/Boss_Enemy");
        Instantiate(bossEnemy, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
