using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hub_Decorator : MonoBehaviour
{
    public GameObject fireball;
    public GameObject player;
    public int counter = 0;
    public int frequency;

    public bool shouldDecorate = true;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        shouldDecorate = true;
        GameObject[] rootObjects = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
        foreach (GameObject i in rootObjects)
        {
            if(i.name == "Manager_Manager")
            {
                shouldDecorate = false;
                break;
            }
        }

        if(shouldDecorate)
        {
            counter++;
            if (counter % frequency == 0)
            {
                GameObject tempFireball = Instantiate(fireball, new Vector3(Random.Range(-300f, 300f), Random.Range(-500, 500f), Random.Range(-300f, 300f)), Quaternion.identity);
                float random = Random.Range(1f, 10f);
                tempFireball.transform.localScale = new Vector3(random, random, random);
                if (Random.Range(0, 5) == 0)
                {
                    tempFireball.GetComponent<Rigidbody>().drag = Random.Range(0, 100);
                }
                //tempFireball.GetComponent<TrailRenderer>().startColor;
            }
        }
    }
}
