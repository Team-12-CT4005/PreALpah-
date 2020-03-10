using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class gameStarter : MonoBehaviour
{
    static public int totalPlayers = 1;
    static public int readyPlayers = 0;

    private void Update()
    {
        if(readyPlayers == totalPlayers)
        {
            StartCoroutine("startGame");
        }
        
    }
    IEnumerator startGame()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("GameLevel");
    }
}
