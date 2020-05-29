using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (playersData.Health1 <= 0 && playersData.Health2 <= 0 && playersData.Health3 <= 0 && playersData.Health4 <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
