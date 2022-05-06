using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class billboard : MonoBehaviour
{
    public Transform playerCam;

    void LateUpdate()
    {
        transform.LookAt(transform.position + playerCam.forward);
    }
}
