using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{
    private Rigidbody rb;
    public playerController player;
    public Player_Components pc;
    public int height;

    public List<GameObject> listOfPlaces;

    public bool isHappening = false;

    public GameObject nextLocationOverride = null;

    public AudioSource walkingSound;
    public AudioSource music;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pc = player.gameObject.GetComponent<Player_Components>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(rb.position.y <= height)
        {
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
        int level = Random.Range(0, 10);
        if(nextLocationOverride == null)
        {
            if (level == 0)
            {
                GameObject nextArea = Instantiate(listOfPlaces[0], new Vector3(0, 0, 0), Quaternion.identity);
                nextArea.name = "Hub";
                walkingSound.mute = true;
                music.mute = false;
                music.pitch += .1f;
            }
            else
            {
                GameObject nextArea = Instantiate(listOfPlaces[1], new Vector3(0, 0, 0), Quaternion.identity);
                nextArea.name = "Manager_Manager";
                walkingSound.mute = false;
                music.mute = true;
            }
        }
        else
        {
            pc.currentHitpoints = pc.maxHitpoints;
            Player_Components.isDead = false;
            GameObject nextArea = Instantiate(nextLocationOverride, new Vector3(0, 0, 0), Quaternion.identity);
            nextLocationOverride = null;
            walkingSound.mute = true;
            music.mute = false;
        }
        pc.currentMagic = pc.maxMagic;
        pc.currentStamina = pc.maxStamina;
    }

    public static void ClearArea()
    {
        GameObject[] rootObjects = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
        foreach (GameObject i in rootObjects)
        {
            if (i.name != "Player" && i.name != "Canvas" && i.name != "Decorator")
            {
                Destroy(i);
            }
        }
    }

    public void ClearAreaOnDeath()
    {
        music.pitch = .8f;
        Player_Components.isDead = true;
        nextLocationOverride = listOfPlaces[0];
        GameObject[] rootObjects = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
        foreach (GameObject i in rootObjects)
        {
            if (i.name != "Player" && i.name != "Canvas" && i.name != "Decorator")
            {
                Destroy(i);
            }
        }
    }
}