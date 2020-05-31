using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int swarmNumber;
    public int ogreNumber;
    public static int enemyNumber = 0;
    public GameObject swarm;
    public GameObject ogre;
    bool inited = false;
    private int Difficulty = 1;
    private void Start()
    {
        swarmNumber = 1;
        ogreNumber = 0;
        spawnWave();
        inited = true;
        StartCoroutine("main");
    }
    IEnumerator main()
    {
        while (true)
        {
            if (inited)
            {
                if(enemyNumber == 0)
                {
                    yield return new WaitForSeconds(1f);
                    Difficulty++;
                    swarmNumber++;
                    ogreNumber++;
                    spawnWave();
                }
                else
                {
                    yield return null;
                }
            }
        }
    }
    private void spawnWave()
    {
        for (int i = 0; i < swarmNumber; i++)
        {
            GameObject Swarm = Instantiate(swarm, new Vector3(30, 1, 0), Quaternion.identity);

            Swarm.name = "Swarm " + i;
            Swarm.GetComponent<flockController>().difficulty = Difficulty;
        }
        for (int i = 0; i < ogreNumber; i++)
        {
            GameObject Archer = Instantiate(ogre, new Vector3(10, 1, 0), Quaternion.identity);

            ogre.name = "Archer " + i;
            enemyNumber++;
        }
    }
}
