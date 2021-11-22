using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Room : MonoBehaviour
{
    public Room_Components components;

    public GameObject enemy_manager;

    public GameObject bossEnemy;

    // Start is called before the first frame update
    void Start()
    {
        components = GetComponent<Room_Components>();
        enemy_manager = transform.Find("Enemy_Manager").gameObject;
        Instantiate(bossEnemy, enemy_manager.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
