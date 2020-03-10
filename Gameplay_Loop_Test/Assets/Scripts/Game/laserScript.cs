using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserScript : MonoBehaviour
{
    private void Start()
    {
        transform.Rotate(0, 90, 0);
        transform.Translate(Vector3.forward);
    }
    private void Update()
    {
        transform.Translate(Vector3.forward);
        if(transform.position.magnitude > 100)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {

        Destroy(this.gameObject);
    }
}
