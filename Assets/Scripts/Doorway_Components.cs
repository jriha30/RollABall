using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorway_Components : MonoBehaviour
{
    public GameObject leftWall;
    public GameObject rightWall;
    public GameObject doorway;

    // Start is called before the first frame update
    void Awake()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            Transform currentTransform = transform.GetChild(i);

            if (currentTransform.name == "Wall (Left)")
                leftWall = currentTransform.gameObject;
            else if (currentTransform.name == "Wall (Right)")
                rightWall = currentTransform.gameObject;
            else if (currentTransform.name == "Doorway")
                doorway = currentTransform.gameObject;
        }
    }
}