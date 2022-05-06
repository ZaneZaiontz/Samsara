using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbAiming : MonoBehaviour
{
    public GameObject player;
    // Update is called once per frame
    void Update()
    {
        Vector3 lookPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        transform.LookAt(lookPos);
    }
}
