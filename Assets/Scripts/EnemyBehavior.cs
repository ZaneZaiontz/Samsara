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

    //private Transform target;
    float fireRate = 6f;

    [SerializeField]
    GameObject projectile;

    [SerializeField]
    Transform shootPoint;

    [SerializeField]
    float turnSpeed = 5;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        //target = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    //attack stuff
    public float damage = 20f;
    public float range = 25f;


    private void Update()
    {
        fireRate -= Time.deltaTime;

        //Vector3 direction = target.position - transform.position; 
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), turnSpeed * Time.deltaTime);
        Vector3 lookPos = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        Distance = Vector3.Distance(player.transform.position, this.transform.position);
        
        if (Distance <= lookRadius && Distance > attackRadius)
        {
            transform.LookAt(lookPos);
            
            follow();
        }
        if (Distance <= lookRadius && Distance <= attackRadius)
        {
            transform.LookAt(lookPos);
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
        agent.isStopped = false;
        animator.SetBool("isShooting", true);   
        if (fireRate <= 0)
        {
            fireRate = 1.45f;
            Shoot();
        }
    }

    void idle()
    {
        agent.isStopped = true;
        animator.SetBool("isWalking", false);
        animator.SetBool("isShooting", false);
    }

    void Shoot()
    {
        Debug.Log($"Shoot position : {shootPoint.position}\nShoot rotation : {shootPoint.rotation}");
        Instantiate(projectile, shootPoint.position, shootPoint.rotation);
    }

}

