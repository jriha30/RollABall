using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Room : MonoBehaviour
{
    public Room_Components components;

    public Get_Room playerRoom;

    public GameObject bossEnemy;

    public GameObject bossEnemyInstance;

    public static Vector3 bossEnemyFinalPosition;

    public GameObject map_Ender;

    public static bool bossAlive = true;

    public bool shouldClear = true;
    public bool bossOn = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRoom = GameObject.Find("Player").GetComponent<Get_Room>();
        components = GetComponent<Room_Components>();
        bossEnemy = Resources.Load<GameObject>("Prefabs/Boss_Enemy");
        map_Ender = Resources.Load<GameObject>("Prefabs/map_Ender");
        bossEnemyInstance = Instantiate(bossEnemy, transform.position, Quaternion.identity);
        bossEnemyInstance.name = "Boss";
        playerRoom.SetBossReference(bossEnemyInstance);
        bossEnemyInstance.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!bossOn && bossAlive && Get_Room.currentRoom == gameObject)
        {
            bossEnemyInstance.GetComponent<Boss_Controller>().shouldControl = true;
            bossOn = true;
        }
        if(shouldClear && !bossAlive)
        {
            GetComponent<Change_Self>().ClearEnemies();
            shouldClear = false;
            Instantiate(map_Ender, bossEnemyFinalPosition, Quaternion.identity);
            print(bossEnemyFinalPosition);
        }
    }
}