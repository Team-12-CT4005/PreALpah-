using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow_script : MonoBehaviour
{
    int velocity = 10;
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<Rigidbody>().velocity = transform.GetComponent<Rigidbody>().velocity * velocity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
