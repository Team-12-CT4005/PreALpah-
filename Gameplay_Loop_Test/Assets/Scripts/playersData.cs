using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playersData : MonoBehaviour
{
    public static int P1_Health = 10;
    public static int P2_Health = 10;
    public static int P3_Health = 10;
    public static int P4_Health = 10;

    public static Transform P1_Position;
    public static Transform P2_Position;
    public static Transform P3_Position;
    public static Transform P4_Position;

    public static int player_num;
    private void Start()
    {
        Debug.Log(P1_Health);
    }
    public void storeHealth(int PlayerNum, int PlayerHealth)
    {
        if (PlayerNum == 1)
        {
            P1_Health = PlayerHealth;
            Debug.Log(P1_Health);
            Health Healthbar = GameObject.Find("YFill").GetComponent<Health>();
            Healthbar.SetHealth(P1_Health * 10);
        }
        if (PlayerNum == 2)
        {
            P2_Health = PlayerHealth;
            Debug.Log(P1_Health);
            Health Healthbar = GameObject.Find("RFill").GetComponent<Health>();
            Healthbar.SetHealth(P1_Health * 10);
        }
        if (PlayerNum == 3)
        {
            P3_Health = PlayerHealth;
            Debug.Log(P1_Health);
            Health Healthbar = GameObject.Find("BFill").GetComponent<Health>();
            Healthbar.SetHealth(P1_Health * 10);
        }
        if (PlayerNum == 4)
        {
            P4_Health = PlayerHealth;
            Debug.Log(P1_Health);
            Health Healthbar = GameObject.Find("GFill").GetComponent<Health>();
            Healthbar.SetHealth(P1_Health * 10);
        }
    }

}
