using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{
    private Rigidbody rb;
    public playerController player;
    public int height;

    public List<GameObject> listOfPlaces;

    public bool isHappening = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(rb.position.y <= height)
        {
            print("WHY IS THIS HAPPENING");
            player.transform.position = new Vector3(0f, 2f, 0f);
            player.isSprinting = false;
            rb.velocity = Vector3.zero;
            ClearArea();
            CreateNextLevel();
            isHappening = false;
        }
    }

    private void CreateNextLevel()
    {
        int level = Random.Range(0, listOfPlaces.Count);
        print("Create Next Level Test   " + level + "   " + listOfPlaces[level]);
        GameObject nextArea = Instantiate(listOfPlaces[level], new Vector3(0, 0, 0), Quaternion.identity);
        if (level == 0)
        {
            print("Manager!");
            nextArea.name = "Manager_Manager";
        }
        else if(level == 1)
        {
            print("Hub!");
            nextArea.name = "Hub";
        }
    }

    public static void ClearArea()
    {
        print("Clear Area Test");
        GameObject[] rootObjects = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
        foreach (GameObject i in rootObjects)
        {
            if (i.name != "Player" && i.name != "Canvas")
            {
                Destroy(i);
            }
        }
    }
}