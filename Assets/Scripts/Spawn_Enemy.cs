using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Enemy : MonoBehaviour
{
    public float enemySpawnClock;
    public float frequency;
    public List<GameObject> enemy;

    public static bool isSpawning = false;

    public GameObject timer;

    public float whenToSpawn = 0;


    // Start is called before the first frame update
    void Start()
    {
        enemySpawnClock = Time_Record.current_Time;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSpawning)
        {
            whenToSpawn = timer.GetComponent<Timer_Functions>().TimeTest(Time_Record.current_Time, frequency);
            isSpawning = true;
        }
        enemySpawnClock = Time_Record.newTime(enemySpawnClock);
        if(enemySpawnClock > whenToSpawn)
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        GameObject currentRoom = Get_Room.currentRoom;
        if(currentRoom != null)
        {
            Room_Components currentRoomComponents = currentRoom.GetComponent<Room_Components>();
            if (currentRoomComponents.numberOfEnemies == 0)
            {
                if(currentRoom.name != "Boss Room")
                {
                    isSpawning = false;
                    return;
                }
            }
            if(currentRoomComponents.isCleared)
            {
                isSpawning = false;
                return;
            }
            Transform roomFloor = currentRoomComponents.floor.transform;
            Transform roomCeiling = currentRoomComponents.ceiling.transform;
            float randomX = Random.Range(roomFloor.position.x - (roomFloor.lossyScale.x / 2) + 2, roomFloor.position.x + (roomFloor.lossyScale.x / 2) - 2);
            float randomY = Random.Range(roomFloor.position.y + 2, roomCeiling.position.y - 2);
            float randomZ = Random.Range(roomFloor.position.z - (roomFloor.lossyScale.z / 2) + 2, roomFloor.position.z + (roomFloor.lossyScale.z / 2) - 2);
            GameObject enemyChoice = enemy[Random.Range(0, enemy.Count)];
            if (enemyChoice.name == "Grounded_Melee_Enemy_Prefab" || enemyChoice.name == "Grounded_Ranged_Enemy_Prefab")
            {
                randomY = 1;
            }
            GameObject tempEnemy = Instantiate(enemyChoice, new Vector3(randomX, randomY, randomZ), Quaternion.identity);
            currentRoomComponents.listOfEnemies.Add(tempEnemy);
            tempEnemy.GetComponent<Enemy_Components>().whichRoom = currentRoom;
            if (enemyChoice.name == "Flying_Melee_Enemy_Prefab")
                tempEnemy.name = "Enemy FM";
            else if (enemyChoice.name == "Flying_Ranged_Enemy_Prefab")
                tempEnemy.name = "Enemy FR";
            else if (enemyChoice.name == "Grounded_Melee_Enemy_Prefab")
                tempEnemy.name = "Enemy GM";
            else if (enemyChoice.name == "Grounded_Ranged_Enemy_Prefab")
                tempEnemy.name = "Enemy GR";
            tempEnemy.transform.parent = transform;
            currentRoomComponents.numberOfEnemies -= 1;
            isSpawning = false;
        }
        else
        {
            isSpawning = false;
            return;
        }
    }
}