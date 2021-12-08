using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TESTING_SCRIPT : MonoBehaviour
{
    public Transform playerCamera;

    public List<GameObject> listOfPowers;
    public GameObject currentPower;
    public int currentPowerIndex = 0;


    public Text powerText;

    // Start is called before the first frame update
    void Start()
    {
        currentPower = listOfPowers[0];
        powerText.text = currentPower.name;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            currentPower.GetComponent<Power_Script>().Activate();
        }
        Vector2 mouseRotation = Input.mouseScrollDelta;
        if (mouseRotation.y < 0)
        {
            currentPowerIndex--;
            if(currentPowerIndex == -1)
            {
                currentPowerIndex = listOfPowers.Count - 1;
            }
            currentPower = listOfPowers[currentPowerIndex];
            powerText.text = currentPower.name;
        }
        else if (mouseRotation.y > 0)
        {
            currentPowerIndex++;
            if(currentPowerIndex == listOfPowers.Count)
            {
                currentPowerIndex = 0;
            }
            currentPower = listOfPowers[currentPowerIndex];
            powerText.text = currentPower.name;
        }
    }
}