using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;

public class RollerAgent : Agent
{
    private Rigidbody rb;
    public Transform Target;

    public Transform floor;
    public float floorSize;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        floorSize = floor.lossyScale.x * 5;
    }

    public override void OnEpisodeBegin()
    {
        // If the Agent fell, zero its momentum
        if (GetComponent<Enemy_Components>().currentHitpoints < 0)
        {
            GetComponent<Enemy_Components>().ResetBoss();
        }

        // Move the target to a new spot
        Target.localPosition = new Vector3(Random.Range(-floorSize, floorSize), 1, Random.Range(-floorSize, floorSize));
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        // Target and Agent positions
        sensor.AddObservation(Target.position);
        sensor.AddObservation(transform.position);
    }
}