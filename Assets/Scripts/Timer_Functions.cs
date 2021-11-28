using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer_Functions : MonoBehaviour
{
    public float timeTest = -1;
    public bool timeTestBool;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (timeTest != -1 && timeTestBool)
        //{
        //    if (Time_Record.current_Time > timeTest)
        //    {
        //        print("Spawned!");
        //        timeTest = -1;
        //        timeTestBool = false;
        //    }
        //}
    }


    public float TimeTest(float startingTime, float addedTime)
    {
        float newTime = startingTime + addedTime;
        return newTime;
    }
}
