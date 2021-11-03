using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Equalize_Doorway : MonoBehaviour
{
    private Transform leftWall;
    private Transform rightWall;
    private Transform doorway;

    // Start is called before the first frame update
    void Start()
    {
        leftWall = transform.Find("Wall (Left)");
        rightWall = transform.Find("Wall (Right)");
        doorway = transform.Find("Doorway");

        Equalize((int)transform.parent.localScale.x);
    }

    float Get_Midpoint(float num1, float num2)
    {
        float tempNum = num1 + num2;
        return tempNum / 2;
    }

    void Equalize(int scale)
    {
        // Scales doorway correctly!
        Vector3 temp = doorway.localScale;
        temp.x /= scale;
        doorway.localScale = temp;
        // Scales doorway correctly!

        // Scales doorway walls to the correct size and position
        float halfWall = transform.lossyScale.x;

        halfWall /= 2;

        float midpoint = Get_Midpoint(1.5f, halfWall) + doorway.position.x;

        Vector3 tempPosition = rightWall.position;

        tempPosition.x = midpoint;
        rightWall.position = tempPosition;

        tempPosition = rightWall.localPosition;

        tempPosition.x *= -1;
        leftWall.localPosition = tempPosition;

        float tempHalfWall = halfWall - 1.5f;

        Vector3 tempScale = rightWall.localScale;
        tempScale.x = tempHalfWall / transform.lossyScale.x;
        rightWall.localScale = tempScale;
        leftWall.localScale = tempScale;
        // Scales doorway walls to the correct size and position
    }
}