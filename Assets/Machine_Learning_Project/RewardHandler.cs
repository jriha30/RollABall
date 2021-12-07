using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors; //new line
using Unity.MLAgents.Actuators;

public class RewardHandler : MonoBehaviour
{
    public Transform floor;
    public BouncerAgent agent;
    private GameObject agentGO;
    private Rigidbody agentRB;
    public BouncerTarget target;
    private GameObject targetGO;
    private Rigidbody targetRB;

    public int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        agentGO = agent.gameObject;
        agentRB = agentGO.GetComponent<Rigidbody>();
        targetGO = target.gameObject;
        targetRB = targetGO.GetComponent<Rigidbody>();
    }

    public void Restart()
    {
        if(floor.localScale.x < 6.5)
        {
            floor.localScale += new Vector3(.1f, 0f, .1f);
        }
        //floor.localScale = new Vector3(Random.Range(2f, 7f), 1, Random.Range(2f, 7f));
        agent.EndEpisode();
        target.EndEpisode();
        counter = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        counter++;
        float distanceBetween = Vector3.Distance(agent.transform.localPosition, target.transform.localPosition);

        if(distanceBetween < 1.42f)
        {
            agent.SetReward(1f);
            target.SetReward(-1f);
            Restart();
        }
        if (counter % 2500 == 0)
        {
            agent.AddReward(-1f);
            target.AddReward(1f);
            //Restart();
        }
    }
}
