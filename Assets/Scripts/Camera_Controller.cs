using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{

    public GameObject player;
    private Vector3 offset;

    public float SpeedH = 10f;
    public float SpeedV = 10f;

    private float yaw = 0f;
    private float pitch = 0f;
    private float minPitch = -75f;
    private float maxPitch = 75f;

    Transform cameraTransform;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
        offset = cameraTransform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        cameraTransform.position = player.transform.position + offset;
        CameraRotate();
    }

    void CameraRotate()
    {
        yaw += Input.GetAxis("Mouse X") * SpeedH;
        pitch -= Input.GetAxis("Mouse Y") * SpeedV;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
        Vector3 cameraVector = new Vector3(pitch, yaw, 0f);
        Vector3 playerVector = new Vector3(0f, yaw, 0f);
        transform.eulerAngles = cameraVector;
        player.transform.eulerAngles = playerVector;
    }
}