using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Enemy : MonoBehaviour
{
    public float enemySpawnClock = 0;
    public float frequency;
    public List<GameObject> enemy;

    public static bool isSpawning = false;

    public Timer_Functions timer;

    public float whenToSpawn = 0;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isSpawning)
        {
            whenToSpawn = timer.TimeTest(Time_Record.current_Time);
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
        Room_Components currentRoomComponents = currentRoom.GetComponent<Room_Components>();
        if(currentRoomComponents.isCleared || currentRoomComponents.numberOfEnemies == 0)
        {
            isSpawning = false;
            return;
        }
        Transform roomFloor = currentRoomComponents.floor.transform;
        float randomX = Random.Range(roomFloor.position.x - (roomFloor.lossyScale.x / 2), roomFloor.position.x + (roomFloor.lossyScale.x / 2));
        float randomY = Random.Range(2f, 10f);
        float randomZ = Random.Range(roomFloor.position.z - (roomFloor.lossyScale.z / 2), roomFloor.position.z + (roomFloor.lossyScale.z / 2));
        GameObject enemyChoice = enemy[Random.Range(0, enemy.Count)];
        GameObject tempEnemy = Instantiate(enemyChoice, new Vector3(randomX, randomY, randomZ), Quaternion.identity);
        currentRoomComponents.listOfEnemies.Add(tempEnemy);
        tempEnemy.GetComponent<Enemy_Components>().whichRoom = currentRoom;
        if(enemyChoice.name == "Flying_Melee_Enemy_Prefab")
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
}