using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBounce : MonoBehaviour
{
    [Header("Sway Settings")]
    [SerializeField] private float smooth;
    [SerializeField] private float swayMulti;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * swayMulti;
        float mouseY = Input.GetAxisRaw("Mouse Y") * swayMulti;

        Quaternion rotateX = Quaternion.AngleAxis(-mouseY, Vector3.right);
        Quaternion rotateY = Quaternion.AngleAxis(mouseX, Vector3.up);

        Quaternion targetRotate = rotateX * rotateY;

        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotate, smooth * Time.deltaTime);

    }
}
