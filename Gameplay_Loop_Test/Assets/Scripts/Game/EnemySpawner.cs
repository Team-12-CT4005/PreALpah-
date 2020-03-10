using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(1, 10)]
    public int Difficulty;

    public int swarmNumber;
    public int archerNumber;

    public GameObject swarm;
    public GameObject archer;

    private void Awake()
    {
        swarmNumber = Difficulty;
        archerNumber = Difficulty - 1;
    }
    private void Start()
    {
        for (int i = 0; i < swarmNumber; i++)
        {
            GameObject Swarm = Instantiate(swarm, new Vector3(30,1,0),Quaternion.identity);

            Swarm.name = "Swarm " + i;
            Swarm.GetComponent<flockController>().difficulty = Difficulty;
        }
        for (int i = 0; i < archerNumber; i++)
        {
            GameObject Archer = Instantiate(archer, new Vector3(10, 1, 0), Quaternion.identity);

            archer.name = "Archer " + i;
        }
    }
}
