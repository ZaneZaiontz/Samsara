using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossShoot : MonoBehaviour
{
    Rigidbody rb;
    private Transform target;

    [SerializeField]
    float speed = 500f;

    //[SerializeField]
    //float damage = 50f;

    private bool collided;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        //Vector3 direction = target.position - transform.position;
        //rb.AddForce(direction * speed * Time.deltaTime); // , ForceMode.Impulse
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
        Debug.Log($"WhereAmI {transform.forward}");

        Destroy(gameObject, 1);
    }
}
