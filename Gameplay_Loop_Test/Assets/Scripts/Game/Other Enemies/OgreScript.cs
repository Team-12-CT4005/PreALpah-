using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OgreScript : MonoBehaviour
{
    public Transform target;
    int MaxSpeed = 5;
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
        GameObject[] Players = GameObject.FindGameObjectsWithTag("Player");
        float nearestDistance = float.MaxValue;
        Transform nearestPlayer = null;
        foreach (GameObject player in Players)
        {

            if (Vector3.Distance(player.transform.position, this.transform.position) < nearestDistance)
            {
                nearestDistance = Vector3.Distance(player.transform.position, this.transform.position);
                nearestPlayer = player.transform;
            }
            else
            {
                Debug.DrawLine(transform.position, player.transform.position, Color.green);
            }

        }
        Debug.DrawLine(transform.position, nearestPlayer.transform.position, Color.red);

        if (SteeringLock == false)
        {
            SteeringLock = true;
            coroutine = Steering(nearestPlayer);
            StartCoroutine(coroutine);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            EnemySpawner.enemyNumber--;
            Debug.Log(EnemySpawner.enemyNumber);
            Destroy(this.gameObject);

        }
    }
    IEnumerator Steering(Transform target)
    {

        while (true)
        {
            if (inited)
            {
                if (Anim.GetBool("ogreRunning"))
                {
                    GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity + Calc(target) * 3 * Time.deltaTime;
                }
                else
                {
                    GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity + Calc(target) * Time.deltaTime;
                }
                transform.LookAt(new Vector3(target.transform.position.x, this.transform.position.y, target.transform.position.z));
                if(GetComponent<Rigidbody>().velocity.magnitude > MaxSpeed){
                    GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * MaxSpeed;
                }
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
    private Vector3 Calc(Transform nearestPlayer)
    {
        Vector3 follow = nearestPlayer.position - transform.position;
        if (Vector3.Distance(nearestPlayer.position, this.transform.position) < 5)
        {
            //AGGRO
            Anim.SetBool("ogreRunning", true);
            Anim.SetBool("ogreWalking", false);
            return (follow * 10);

        }
        else
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
           //PASSIVE
            Anim.SetBool("ogreRunning", false);
            Anim.SetBool("ogreWalking", true);
            return (follow);
        }
    }
}











