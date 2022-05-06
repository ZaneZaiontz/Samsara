using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAI : MonoBehaviour
{
    public NavMeshAgent boss;
    public GameObject player;
    
    //Probably dont need this
    public float Distance;
    //private Animator animator;
    
    public float lookRadius = 50f;
    public float attackRadius = 75f;

    private Transform target;
    float fireRate = 6f;

    private bool sideFire = false;

    [SerializeField]
    GameObject projectile;

    [SerializeField]
    Transform lightAttack;
    [SerializeField]
    Transform darkAttack;

    [SerializeField]
    float turnSpeed = 15;

    //attack stuff
    //public float damage = 25f;
    //public float range = 50f;

    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
        boss = GetComponent<NavMeshAgent>();
        //playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
        Debug.Log(player);

    }

    private void Update()
    {
        fireRate -= Time.deltaTime;

        //Vector3 direction = target.position - transform.position; 
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), turnSpeed * Time.deltaTime);
        Vector3 lookPos = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        Distance = Vector3.Distance(player.transform.position, this.transform.position);

        if (Distance <= lookRadius && Distance > attackRadius)
        {
            Debug.Log($"Boss looking at : {lookPos}");
            transform.LookAt(lookPos);
            //follow();
        }
        if (Distance <= lookRadius && Distance <= attackRadius)
        {
            //Debug.Log($"Boss looking at : {lookPos}");
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
        boss.isStopped = false;
        //animator.SetBool("isShooting", false);
        //animator.SetBool("isWalking", true);
        Vector3 destination = player.transform.position;
        boss.SetDestination(destination);
    }

    private void attack()
    {
        boss.isStopped = false;
        //animator.SetBool("isShooting", true);
        if (fireRate <= 0)
        {
            fireRate = 1.45f;
            Shoot();
        }
    }

    void idle()
    {
        boss.isStopped = true;
        //animator.SetBool("isWalking", false);
        //animator.SetBool("isShooting", false);
    }

    void Shoot()
    {
        if (sideFire)
        {
            Instantiate(projectile, lightAttack.position, lightAttack.rotation);
            sideFire = false;
        }
        else
        {
            Instantiate(projectile, darkAttack.position, darkAttack.rotation);
            sideFire = true;
        }
        //Debug.Log($"Shoot position : {shootPoint.position}\nShoot rotation : {shootPoint.rotation}");
        
    }

}

