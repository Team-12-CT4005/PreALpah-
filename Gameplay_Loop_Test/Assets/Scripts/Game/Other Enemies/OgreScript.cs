using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OgreScript : MonoBehaviour
{
    public Transform target;
    int MaxSpeed = 6;
    private Animator Anim;
    private IEnumerator coroutine;
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
        coroutine = Steering(nearestPlayer);
        StartCoroutine(coroutine);
    }

    IEnumerator Steering(Transform target)
    {
        Calc(target);
    }
    private void Calc (Transform nearestPlayer)
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
