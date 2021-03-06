﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public static bool Paused = false;
    public GameObject menu;
    public GameObject Hud;
   
    // Update is called once per frame
    void Start()
    {
        Hud.SetActive(true);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))// if the user presses the escape key
        {
            if (Paused)
            {
                Resume();// if the user is pause play the resum function
                Hud.SetActive(true);
            }
            else
            {
                Pause();// otherwise play the pause fucntion
                Hud.SetActive(false);
            }
        }
    }
    public void Resume()
    {
        menu.SetActive(false);// deactivates the pause menu
        Time.timeScale = 1f; // resumes normal time
        Paused = false; // sets pause to false
        Hud.SetActive(true);
    }
    void Pause()
    {
        Hud.SetActive(false);
        menu.SetActive(true); //activates the pause menu
        Time.timeScale = 0f; // freezes time
        Paused = true;// sets pause to true 
    }
    public void Quit()
    {
        Application.Quit();// quits the application
    }
    public void Menu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);// if the user selects the menu option it will return to the previous menu scene
    }
}
