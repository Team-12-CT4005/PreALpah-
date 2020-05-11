using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherScript : MonoBehaviour
{
    bool isHostile = false;
    protected int aggroDistance = 25;
    protected int minDistance = 20;

    private void Update()
    {
        Transform player1 = GameObject.Find("Player1").GetComponent<Transform>();
        float playerDistance = Vector3.Distance(this.transform.position, GameObject.Find("Player1").GetComponent<Transform>().position);
        if(playerDistance < aggroDistance)
        {
            Vector3 playerXYLocation = new Vector3(player1.position.x, this.transform.position.y, player1.position.z);
            transform.LookAt(playerXYLocation);
        }
        else if (playerDistance > aggroDistance)
        {
            transform.rotation = Quaternion.identity;
        }
    }
}
