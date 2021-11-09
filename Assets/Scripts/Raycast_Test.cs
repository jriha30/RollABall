using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast_Test : MonoBehaviour
{
    public Set_Text canvas;

    public AudioSource shootingSound;

    public GameObject projectile;

    public List<GameObject> projectileList;

    public bool isCharging;

    public float charge = .75f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            isCharging = true;
        }

        if(Input.GetMouseButtonUp(0))
        {
            if(canvas.isActiveAndEnabled)
            canvas.ChangeTextOnAttack(Time_Record.current_Time);

            GameObject projectileObject = Instantiate(projectile, GetComponent<playerController>().playerCamera.transform.forward, Quaternion.identity);
            projectileObject.GetComponent<Get_Shot>().startPoint = GetComponent<playerController>().playerCamera.transform.position;
            projectileObject.GetComponent<Get_Shot>().direction = GetComponent<playerController>().playerCamera.transform.forward;
            projectileObject.GetComponent<Get_Shot>().parent = gameObject;
            projectileObject.GetComponent<Get_Shot>().charge = charge;

            isCharging = false;
            charge = .75f;


            shootingSound.Play();
        }
    }

    void FixedUpdate()
    {
        if(isCharging && charge < 4)
        {
            charge += .01f;
        }
        if(charge >= 4)
        {
            charge = 4;
        }
    }
}