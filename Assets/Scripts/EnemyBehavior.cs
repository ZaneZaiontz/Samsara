using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject player;
    public float Distance;
    private Animator animator;
    public float lookRadius;
    public float attackRadius;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

    }


    //attack stuff
    public float damage = 20f;
    public float range = 25f;


    private void Update()
    {
        Distance = Vector3.Distance(player.transform.position, this.transform.position);

        if (Distance <= lookRadius && Distance > attackRadius)
        {
            follow();
        }
        if (Distance <= lookRadius && Distance <= attackRadius)
        {
            attack();
        }
        if (Distance > lookRadius)
        {
            idle();
        }
    }

    private void follow()
    {
        agent.isStopped = false;
        animator.SetBool("isShooting", false);
        animator.SetBool("isWalking", true);
        Vector3 destination = player.transform.position;
        agent.SetDestination(destination);
    }

    private void attack()
    {
        animator.SetBool("isShooting", true);        
    }

    void idle()
    {
        agent.isStopped = true;
        animator.SetBool("isWalking", false);
        animator.SetBool("isShooting", false);
    }

}

