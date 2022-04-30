using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public GameObject player;

    bool isAngered;

    public float agroDistance;

    public float Distance;



    //attack stuff
    public float damage = 20f;
    public float range = 25f;

 


    private void Update()
    {
        Distance = Vector3.Distance(player.transform.position, this.transform.position);

        if (Distance < agroDistance)
        {
            isAngered = true;
        }
        else
        {
            isAngered = false;
        }

        if (isAngered)
        {
            agent.isStopped = false;
            agent.SetDestination(player.transform.position);

        }
        if (!isAngered)
        {
            agent.isStopped = true;
        }
    }

}