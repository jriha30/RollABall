using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_Enemy_Controller : MonoBehaviour
{
    public GameObject player;

    public List<Vector3> listOfLocs;

    public float speed;

    public float distanceFromPlayer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        listOfLocs.Add(player.transform.position + new Vector3(1, 0, 0));
        listOfLocs.Add(player.transform.position + new Vector3(-1, 0, 0));
        listOfLocs.Add(player.transform.position + new Vector3(0, 0, 1));
        listOfLocs.Add(player.transform.position + new Vector3(0, 0, -1));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GroundedMeleeControl();
    }



    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            if (player.GetComponent<Player_Functions>().Dodge(player.GetComponent<Player_Components>().armorClass))
            {
                player.GetComponent<Player_Functions>().GetHit(GetComponent<Enemy_Components>().damage);
            }
            GetComponent<Enemy_Functions>().GetHit(1);
        }
    }

    private void GroundedMeleeControl()
    {
        listOfLocs[0] = player.transform.position + new Vector3(distanceFromPlayer, 0, 0);
        listOfLocs[1] = player.transform.position - new Vector3(distanceFromPlayer, 0, 0);
        listOfLocs[2] = player.transform.position + new Vector3(0, 0, distanceFromPlayer);
        listOfLocs[3] = player.transform.position - new Vector3(0, 0, distanceFromPlayer);

        Vector3 chosenLocation = listOfLocs[Random.Range(0, listOfLocs.Count)];

        Vector3 newEnemyPos = transform.position - chosenLocation;

        transform.position -= newEnemyPos / 100 * speed;
    }

}
