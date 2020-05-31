using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherScript : MonoBehaviour
{
    private Animator Anim;
    int MaxSpeed = 5;
    private bool isAttcking = false;
    private IEnumerator coroutine;
    private bool inited = true;
    public GameObject arrow;
    public bool SteeringLock = false;
    private int ammo = 3;
    private void Start()
    {
        Anim = GetComponent<Animator>();
        StartCoroutine("reloading");
    }
    IEnumerator reloading()
    {
        while (true)
        {
            if (inited)
            {
                if (ammo < 3)
                {
                    yield return new WaitForSeconds(0.5f);
                    ammo++;
                }
            }
        }
    }
    private void Update()
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
    IEnumerator Steering(Transform target)
    {
        while (true)
        {
            if (inited)
            {
                GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity + Calc(target) * 3 * Time.deltaTime;
                if (GetComponent<Rigidbody>().velocity.magnitude > MaxSpeed)
                {
                    GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * MaxSpeed;
                }
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
    private Vector3 Calc(Transform target)
    {
        Vector3 follow = target.position - transform.position;
        if (Vector3.Distance(target.position, this.transform.position) < 7)
        {
            //Retreat
            Anim.SetBool("IsRunning", true);
            transform.LookAt(new Vector3(target.transform.position.x, this.transform.position.y, target.transform.position.z));
            transform.Rotate(0, 180, 0);
            return (follow * -5);

        }
        else if (Vector3.Distance(target.position, this.transform.position) > 13)
        {
            Anim.SetBool("IsRunning", true);
            //Chase
            transform.LookAt(new Vector3(target.transform.position.x, this.transform.position.y, target.transform.position.z));
            return (follow);

        }
        else
        {
            //shoot
            Anim.SetBool("IsRunning", false);
            transform.LookAt(new Vector3(target.transform.position.x, this.transform.position.y, target.transform.position.z));
            StartCoroutine("attack");
            return (Vector3.zero);
        }
    }

    IEnumerator attack()
    {
        if (ammo == 0)
        {
            yield return null;
        }
        else if (ammo > 0 && isAttcking == false)
        {
            Debug.Log("shot!");
            isAttcking = true;
            ammo--;
            GameObject Arrow = Instantiate(arrow, this.transform.position, transform.rotation) as GameObject;
            yield return new WaitForSeconds(0.2f);
            isAttcking = false;
            yield return null;
        }
    }
}
