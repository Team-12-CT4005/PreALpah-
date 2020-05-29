using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lobby : MonoBehaviour
{
    public GameObject Object;
    public static bool Paused2 = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Confirm()
    {
        Object.SetActive(false);// deactivates the pause menu
        Time.timeScale = 1f; // resumes normal time
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
