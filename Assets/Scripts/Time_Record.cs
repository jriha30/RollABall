using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time_Record : MonoBehaviour
{
    public Time_Record clock;
    public static float current_Time;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        current_Time = newTime(current_Time);
    }

    public static float newTime(float time)
    {
        return time + Time.deltaTime;
    }
}