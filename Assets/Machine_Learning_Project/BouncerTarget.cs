using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors; //new line
using Unity.MLAgents.Actuators;

public class BouncerTarget : Agent
{
    public float distanceToOpponent;

    public Transform floor;

    public Transform opponent;

    private Rigidbody opponentrb;

    private Rigidbody rb;

    public float acceleration;
    public float speedLimit;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        opponentrb = opponent.gameObject.GetComponent<Rigidbody>();
    }

    public override void OnEpisodeBegin()
    {
        //acceleration = Random.Range(5, 20);

        float floorSizeHalfX = floor.localScale.x * 5;
        float floorSizeHalfZ = floor.localScale.z * 5;

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.localPosition = new Vector3(Random.Range(-floorSizeHalfX, floorSizeHalfX), .5f, Random.Range(-floorSizeHalfZ, floorSizeHalfZ));

        // COMMENT OUT IF TRAINING BOTH AGENTS SIMULTANEOUSLY.
        //opponentrb.velocity = Vector3.zero;
        //opponentrb.angularVelocity = Vector3.zero;
        //opponent.localPosition = new Vector3(Random.Range(-floorSizeHalfX, floorSizeHalfX), .5f, Random.Range(-floorSizeHalfZ, floorSizeHalfZ));
        
        distanceToOpponent = Vector3.Distance(transform.localPosition, opponent.localPosition);
        opponent.GetComponent<BouncerAgent>().distanceToOpponent = distanceToOpponent;
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(opponent.localPosition.x);
        sensor.AddObservation(opponent.localPosition.z);
        sensor.AddObservation(transform.localPosition.x);
        sensor.AddObservation(transform.localPosition.z);

        sensor.AddObservation(opponentrb.velocity.x);
        sensor.AddObservation(opponentrb.velocity.z);
        sensor.AddObservation(rb.velocity.x);
        sensor.AddObservation(rb.velocity.z);
    }

    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        float currentDistance = distanceToOpponent;
        Vector3 controlSignal = Vector3.zero;
        controlSignal.x = actionBuffers.ContinuousActions[0];
        controlSignal.z = actionBuffers.ContinuousActions[1];

        if (rb.velocity.magnitude < speedLimit)
        {
            rb.AddForce(controlSignal * acceleration);
        }

        distanceToOpponent = Vector3.Distance(transform.localPosition, opponent.localPosition);
        // COMMENT OUT IF TRAINING BOTH AGENTS SIMULTANEOUSLY.
        //if (distanceToOpponent < 1.42f)
        //{
        //    AddReward(-1f);
        //    EndEpisode();
        //}
        if (transform.localPosition.y < 0)
        {
            AddReward(-1f);
            EndEpisode();
        }
        if (currentDistance <= distanceToOpponent)
        {
            AddReward(.1f);
        }
        else if (currentDistance > distanceToOpponent)
        {
            AddReward(-.01f);
        }
    }
}