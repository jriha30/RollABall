using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate_Room : MonoBehaviour
{
    public GameObject floor;
    private GameObject northWall;
    public GameObject southWall;
    public GameObject eastWall;
    public GameObject westWall;




    // Start is called before the first frame update
    void Awake()
    {

        northWall = Resources.Load<GameObject>("Prefabs/Doorway_Prefab");
        transform.localScale = new Vector3(Random.Range(2, 5), 1f, Random.Range(2, 5));
        int transformX = (int)transform.localScale.x;
        int transformZ = (int)transform.localScale.z;


        Vector3 tempVectorEastWest = eastWall.transform.localScale;
        tempVectorEastWest.x /= transformX;
        eastWall.transform.localScale = tempVectorEastWest;
        westWall.transform.localScale = tempVectorEastWest;


        Vector3 tempVectorNorthSouth = southWall.transform.localScale;
        tempVectorNorthSouth.z /= transformZ;
        northWall.transform.localScale = tempVectorNorthSouth;
        southWall.transform.localScale = tempVectorNorthSouth;
    }
}