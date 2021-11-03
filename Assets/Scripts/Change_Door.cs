using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Door : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseDoor()
    {
        BoxCollider currCollider = GetComponent<Doorway_Components>().doorway.GetComponent<BoxCollider>();
        MeshRenderer currRenderer = GetComponent<Doorway_Components>().doorway.GetComponent<MeshRenderer>();
        currCollider.enabled = true;
        currRenderer.enabled = true;
    }

    public void OpenDoor()
    {
        BoxCollider currCollider = GetComponent<Doorway_Components>().doorway.GetComponent<BoxCollider>();
        MeshRenderer currRenderer = GetComponent<Doorway_Components>().doorway.GetComponent<MeshRenderer>();
        currCollider.enabled = false;
        currRenderer.enabled = false;
    }
}
