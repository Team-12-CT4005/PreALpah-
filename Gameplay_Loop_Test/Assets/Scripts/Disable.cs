using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable : MonoBehaviour
{
    public GameObject ANim;
    public GameObject Video;
    public GameObject MEnu;
    private float timer;
    void Start()
    {
        timer = 8.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Destroy(ANim);
            Destroy(Video);
            Destroy(MEnu);
        }
    }
}
