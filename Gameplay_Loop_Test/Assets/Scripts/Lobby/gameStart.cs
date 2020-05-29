using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class gameStart : MonoBehaviour
{
    static public int totalPlayers = 0;
    static public int readyPlayers = 0;
    private void Awake()
    {
        GameObject.Find("Player1").SetActive(false);

    }
    private void Update()
    {
        if(readyPlayers == totalPlayers && totalPlayers > 0)
        {
            StartCoroutine("startGame");
        }


        if (Input.GetAxis("StartButton1") > 0 && playersData.playing1 == false)
        {
            Debug.Log("start button pressed");
            playersData.playing1 = true;
            GameObject.Find("Player1").SetActive(true);
        }
        if (Input.GetAxis("StartButton2") > 0 && playersData.playing2 == false)
        {
            Debug.Log("start button pressed");
            playersData.playing2 = true;
        }
        if (Input.GetAxis("StartButton3") > 0 && playersData.playing3 == false)
        {
            Debug.Log("start button pressed");
            playersData.playing3 = true;
        }
        if (Input.GetAxis("StartButton4") > 0 && playersData.playing4 == false)
        {
            Debug.Log("start button pressed");
            playersData.playing4 = true;
        }
    }
    IEnumerator startGame()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("GameLevel");
    }

}
