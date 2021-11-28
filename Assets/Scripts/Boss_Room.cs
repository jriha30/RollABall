using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Room : MonoBehaviour
{
    public Room_Components components;

    public Get_Room playerRoom;

    public GameObject bossEnemy;

    // Start is called before the first frame update
    void Start()
    {
        playerRoom = GameObject.Find("Player").GetComponent<Get_Room>();
        components = GetComponent<Room_Components>();
        bossEnemy = Resources.Load<GameObject>("Prefabs/Boss_Enemy");
        GameObject bossEnemyObj = Instantiate(bossEnemy, transform.position, Quaternion.identity);
        bossEnemyObj.name = "Boss";
        playerRoom.SetBossReference(bossEnemyObj);
        bossEnemyObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Get_Room.currentRoom == gameObject)
        {
            bossEnemy.GetComponent<Boss_Controller>().shouldControl = true;
        }
    }
}