using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Lighting : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    public GameObject directionalLightObject;
    public GameObject cameraObject;
    private Light directionalLight;
    private new Camera camera;
    public Material floorMaterial;
    private Color32 color;

    public Color32 initialColor;
    public Color32 finalColor;

    private int frames = 0;
    private int upOrDown = 1;

    void Start()
    {
        directionalLight = directionalLightObject.GetComponent<Light>();
        camera = cameraObject.GetComponent<Camera>();
        offset = transform.position - player.transform.position;
    }

    private void Update()
    {
        transform.position = player.transform.position + offset;
    }

    private void FixedUpdate()
    {
        //color = ChangeColor(color, initialColor, finalColor);
        //frames++;
        if (frames % 1 == 0)
        {
            if (color.r == 255)
            {
                upOrDown = -1;
            }
            else if (color.r == 0)
            {
                upOrDown = 1;
            }
            if (upOrDown == 1)
            {
                color.r += 1;
                color.g += 1;
                color.b += 1;
            }
            else if (upOrDown == -1)
            {
                color.r -= 1;
                color.g -= 1;
                color.b -= 1;
            }
        directionalLight.color = color;
        camera.backgroundColor = color;
        floorMaterial.color = color;
        }
    }

    public Color32 ChangeColor(Color32 currColor, Color32 color1, Color32 color2)
    {
        if(currColor.Equals(color1))
        {
            return color2;
        }
        else
        {
            return color1;
        }
    }
}