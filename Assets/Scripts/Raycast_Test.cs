using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast_Test : MonoBehaviour
{
    public Set_Text canvas;

    public AudioSource shootingSound;

    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(canvas.isActiveAndEnabled)
            canvas.ChangeTextOnAttack(Time_Record.current_Time);

            GameObject projectileObject = Instantiate(projectile, transform.position, Quaternion.identity);
            projectileObject.GetComponent<Get_Shot>().startPoint = GetComponent<playerController>().playerCamera.transform.position;
            projectileObject.GetComponent<Get_Shot>().direction = GetComponent<playerController>().playerCamera.transform.forward;




            RaycastHit hit;
            if (Physics.Raycast(GetComponent<playerController>().playerCamera.transform.position, GetComponent<playerController>().playerCamera.transform.forward, out hit, 100))
            {
                GameObject tempObject = hit.collider.gameObject;
                if (tempObject.tag == "Enemy")
                {
                    tempObject.GetComponent<Enemy_Components>().whichRoom.GetComponent<Room_Components>().listOfEnemies.Remove(tempObject);
                    Destroy(hit.collider.gameObject);
                }
            }

            shootingSound.Play();
            //print(GetComponent<playerController>().playerCamera.rotation.eulerAngles);
        }
    }
}