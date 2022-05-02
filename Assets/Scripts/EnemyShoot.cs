using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    float speed = 500f;

    [SerializeField]
    float damage = 50f;

    private bool collided;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Transform target = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 direction = target.position - transform.position;
        rb.AddForce(direction * speed * Time.deltaTime);

        Destroy(gameObject, 2);
    }
    
}
