using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDirection : MonoBehaviour
{
    public Transform Player;
    // Update is called once per frame
    void Update()
    {
    Vector3 inputDirection = Vector3.zero;
    inputDirection.x = Input.GetAxis("LeftJoystickVertical");
    inputDirection.z = Input.GetAxis("LeftJoystickHorizontal");
    inputDirection.Normalize();
    transform.position = Player.position + inputDirection;
    }
}
