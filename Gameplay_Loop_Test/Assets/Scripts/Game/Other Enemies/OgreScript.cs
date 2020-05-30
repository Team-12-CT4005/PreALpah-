using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OgreScript : MonoBehaviour
{
    public Transform target;
    int MinSpeed = 3;
    int MaxSpeed = 6;
    private Animator Anim;
    private IEnumerator coroutine;
    private bool inited = true;
    public bool SteeringLock = false;
    // Update is called once per frame
    private void Awake()
    {
        Anim = GetComponent<Animator>();
    }
    void Update()
    {
        GameObject[] Players = GameObject.FindGameObjectsWithTag("player");
        float nearestDistance = float.MaxValue;
        Transform nearestPlayer = null;
        foreach (GameObject player in Players)
        {
            if(Vector3.Distance(player.transform.position, this.transform.position) < nearestDistance){
                nearestDistance = Vector3.Distance(player.transform.position, this.transform.position);
                nearestPlayer = player.transform;
            }
            else
            {
                return;
            }
        }
        if(SteeringLock == false)
        {
            SteeringLock = true;
            coroutine = Steering(nearestPlayer);
            StartCoroutine(coroutine);
        }

        if (GetComponent<Rigidbody>().velocity.magnitude > 0)
        {
            Anim.SetBool("ogreRunning", true);
        }
        else
        {
            Anim.SetBool("ogreRunning", false);
        }
    }

    IEnumerator Steering(Transform target)
    {
        
        while (true)
        {
            if (inited)
            {
                GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity + Calc(target) * 3 * Time.deltaTime;
                transform.LookAt(new Vector3(target.transform.position.x, this.transform.position.y, target.transform.position.z));
                if (GetComponent<Rigidbody>().velocity.magnitude > MaxSpeed)
                {
                    GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * MaxSpeed;
                }
                if (GetComponent<Rigidbody>().velocity.magnitude < MinSpeed)
                {
                    GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * MinSpeed;
                }
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
    private Vector3 Calc (Transform nearestPlayer)
    {
        Vector3 follow = nearestPlayer.position - transform.position;
        if(Vector3.Distance(nearestPlayer.position, this.transform.position) < 10)
        {
            //AGGRO
            return (follow * 10);
        }
        else
        {
            //PASSIVE
            return (follow);
        }
    }
}
