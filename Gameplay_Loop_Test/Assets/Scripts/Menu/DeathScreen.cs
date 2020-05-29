using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (playersData.P1_Health <= 0 && playersData.P2_Health <= 0 && playersData.P3_Health <= 0 && playersData.P4_Health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
