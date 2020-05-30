using UnityEngine;
using System.Collections;

public class flockBehavior : MonoBehaviour
{
    private Animator Anim;
    private GameObject Controller;
    private bool inited = false;
    private float minVelocity;
    private float maxVelocity;
    private float randomness;
    private GameObject chase;

    void Start()
    {
        Anim = GetComponentInChildren<Animator>();
        StartCoroutine("BoidSteering");
    }

    IEnumerator BoidSteering()
    {
        Anim.SetBool("ratRunning", true);
        while (true)
        {
            if (inited)
            {
                GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity + Calc() * 3 * Time.deltaTime;

                // enforce minimum and maximum speeds for the boids
                float speed = GetComponent<Rigidbody>().velocity.magnitude;
                transform.LookAt(new Vector3(chase.transform.position.x, this.transform.position.y, chase.transform.position.z));
                if (speed > maxVelocity)
                {
                    GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * maxVelocity;
                }
                else if (speed < minVelocity)
                {
                    GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * minVelocity;
                }
            }

            yield return new WaitForSeconds(0.1f);
        }
    }

    private Vector3 Calc()
    {
        flockController boidController = Controller.GetComponent<flockController>();
        Vector3 flockCenter = boidController.swarmCenter;
        //Vector3 flockVelocity = boidController.swarmVelocity;
        Vector3 follow = chase.transform.position;

        flockCenter = flockCenter - transform.localPosition;
        //flockVelocity = flockVelocity - GetComponent<Rigidbody>().velocity;
        follow = follow - transform.position;
        if(Vector3.Distance(chase.transform.position, this.transform.position ) < 10)
        {
            return (follow * 10);
        }
        else
        {
            return (flockCenter  + follow); //+ veloc
        }

    }

    public void SetController(GameObject theController)
    {
        Controller = theController;
        flockController boidController = Controller.GetComponent<flockController>();
        minVelocity = boidController.minVelocity;
        maxVelocity = boidController.maxVelocity;
        chase = boidController.chase;
        inited = true;
    }
}