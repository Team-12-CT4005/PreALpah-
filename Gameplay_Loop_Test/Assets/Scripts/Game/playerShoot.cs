using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoot : MonoBehaviour
{
    public Transform laser;
    void Update()
    {
        bool isShooting = Input.GetButton("RightTrigger");
        if (isShooting)
        {
            Debug.Log("right trigger detected");
            Instantiate(laser, this.transform.position, this.transform.rotation);
        }
    }
}
