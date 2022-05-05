using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Shooter : MonoBehaviour
{

    private AudioSource spellSound;
    public Camera cam;
    private Vector3 destination;
    public GameObject projectile;
    public Transform firePoint;
    public float projectileSpeed = 30;
    private float timeToFire;
    public float fireRate = 4;
    public PlayerStats player;
    private Coroutine regen;
    float damage = 25f;
    private WaitForSeconds regenTic = new WaitForSeconds(.2f);


    // Start is called before the first frame update
    void Start()
    {
        spellSound = GetComponent<AudioSource>();   
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time > timeToFire && player.CurrentMana >= 5)
        {
            spellSound.Play();
            player.CurrentMana -= 5;
            timeToFire = Time.time + 1/fireRate;
            ShootProjectile();
            Shot();
            if(regen != null)
            {
                StopCoroutine(regen);
            }
            regen = StartCoroutine(RegenMana());
        }
    }

    void ShootProjectile()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
            destination = hit.point;
        else
            destination = ray.GetPoint(100);

      
        InstantiateProjectile(firePoint);

    }

    void InstantiateProjectile(Transform firePoint)
    {
        var projectileObj = Instantiate(projectile, firePoint.position, Quaternion.identity) as GameObject;
        projectileObj.GetComponent<Rigidbody>().velocity = (destination - firePoint.position).normalized * projectileSpeed;
    }

    void Shot()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 100))
        {
            EnemyHealth enemy = hit.transform.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.DeductHealth(damage);
            }
        }
    }

    private IEnumerator RegenMana()
    {
        yield return new WaitForSeconds(2);
        // Zane: I increased the regen speed 
        while (player.CurrentMana < player.MaxMana)
        {
            player.CurrentMana = (player.CurrentMana * 1.65f) + 1f;
            yield return regenTic;
        }
        player.CurrentMana = 100f;
        regen = null;
    }

}
