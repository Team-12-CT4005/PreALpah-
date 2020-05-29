using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script contains all of the functions 
//i used a lot across different parts of the game
//so storing them all here makes it easier.
public class commonEvents : MonoBehaviour
{
    public void showPlayers()
    {
        GameObject.Find("Player1").GetComponent<MeshRenderer>().enabled = true;
        GameObject.Find("Player2").GetComponent<MeshRenderer>().enabled = true;
        GameObject.Find("Player3").GetComponent<MeshRenderer>().enabled = true;
        GameObject.Find("Player4").GetComponent<MeshRenderer>().enabled = true;
    }
    public void hidePlayers()
    {
        GameObject.Find("Player1").GetComponent<MeshRenderer>().enabled = false;
        GameObject.Find("Player2").GetComponent<MeshRenderer>().enabled = false;
        GameObject.Find("Player3").GetComponent<MeshRenderer>().enabled = false;
        GameObject.Find("Player4").GetComponent<MeshRenderer>().enabled = false;
    }
    public void lockPlayers()
    {
        GameObject.Find("Player1").GetComponent<playerController1>().enabled = false;
        //GameObject.Find("Player2").GetComponent<playerMovement>().enabled = false;
        //GameObject.Find("Player3").GetComponent<playerMovement>().enabled = false;
        //GameObject.Find("Player4").GetComponent<playerMovement>().enabled = false;
    }
    public void unlockPlayers()
    {
        GameObject.Find("Player1").GetComponent<playerController1>().enabled = true;
        //GameObject.Find("Player2").GetComponent<playerMovement>().enabled = true;
        //GameObject.Find("Player3").GetComponent<playerMovement>().enabled = true;
        //GameObject.Find("Player4").GetComponent<playerMovement>().enabled = true;
    }
    public void centerPlayers()
    {
        GameObject.Find("Player1").transform.position = new Vector3(-1, 1, -1);
        GameObject.Find("Player2").transform.position = new Vector3(-1, 1, 1);
        GameObject.Find("Player3").transform.position = new Vector3(1, 1, -1);
        GameObject.Find("Player4").transform.position = new Vector3(1, 1, 1);
    }

    public void hidePlayerNumbers()
    {
        GameObject.Find("P1").GetComponent<MeshRenderer>().enabled = false;
        GameObject.Find("P2").GetComponent<MeshRenderer>().enabled = false;
        GameObject.Find("P3").GetComponent<MeshRenderer>().enabled = false;
        GameObject.Find("P4").GetComponent<MeshRenderer>().enabled = false;
    }
    public void showPlayerNumbers()
    {
        GameObject.Find("P1").GetComponent<MeshRenderer>().enabled = true;
        GameObject.Find("P2").GetComponent<MeshRenderer>().enabled = true;
        GameObject.Find("P3").GetComponent<MeshRenderer>().enabled = true;
        GameObject.Find("P4").GetComponent<MeshRenderer>().enabled = true;
    }

}
