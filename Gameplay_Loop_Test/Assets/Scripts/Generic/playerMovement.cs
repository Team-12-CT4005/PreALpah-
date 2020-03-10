using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField]
    [Range(0.1f, 1f)]
    float speed = 0.3f;

    public Transform target;

    // Update is called once per frame
    void Update()
    {
        Vector3 moveVector = Vector3.zero;
        moveVector.x = Input.GetAxis("LeftJoystickVertical");
        moveVector.z = Input.GetAxis("LeftJoystickHorizontal");
        moveVector.Normalize();
        transform.position += moveVector * speed;
        transform.LookAt(target);
    }
}
