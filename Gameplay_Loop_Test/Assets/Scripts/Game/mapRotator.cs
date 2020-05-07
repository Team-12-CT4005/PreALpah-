using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapRotator : MonoBehaviour
{
    int[] availableMaps = { 0 , 1 , 2 };
    int mapNumber;
    int newMapNumber;
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {

            StartCoroutine("transition");  //Moves the map

        }

    }
    public void lockCharacters()
    {
        GameObject.Find("Player1").GetComponent<playerController>().enabled = false;
        GameObject.Find("Player1").GetComponent<Rigidbody>().useGravity = false;
        return;
    }
    public void unlockCharacters()
    {
        GameObject.Find("Player1").GetComponent<playerController>().enabled = true;
        GameObject.Find("Player1").GetComponent<Rigidbody>().useGravity = true;
    }
    IEnumerator transition()
    {
        lockCharacters();
        newMapNumber = Random.Range(0,3);
        int mapDestination = -200 * (newMapNumber - mapNumber);
        Debug.Log(newMapNumber);
        for (int i = 0; i < 100; i++)
        {
            transform.Translate(mapDestination / 100, 0, 0);
            yield return new WaitForSeconds(0.01f);

        }
        mapNumber = newMapNumber;
        unlockCharacters();
    }
}
