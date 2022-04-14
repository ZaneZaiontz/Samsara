using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public GameObject impactX;
    private bool collided;
    public float TimeLeft = 5;

    void Update()
    {
        TimeLeft -= Time.deltaTime;
        if (TimeLeft<0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision co)
    {
        if (co.gameObject.tag != "Bullet" && co.gameObject.tag!="Player" && !collided) 
        {
            collided = true;

            var impact = Instantiate(impactX, co.contacts[0].point,Quaternion.identity) as GameObject;
            Destroy(impact, 2);
            Destroy(gameObject);
        }

    }
}
