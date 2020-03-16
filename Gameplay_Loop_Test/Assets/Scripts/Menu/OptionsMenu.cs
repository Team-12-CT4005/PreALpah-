using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    Resolution[] resolutions;
    public Dropdown ResDrop;
    private void Start()
    {
        resolutions = Screen.resolutions; //stores all available resolutions into the resolutions array

        ResDrop.ClearOptions();// Clears the preset options in the assigned dropdown menu

        List<string> options = new List<string>();
        int CurrentRes = 0;// creates a list that will hold the new set of resolution options

        for (int i = 0; i < resolutions.Length; i++)//For each option in the resolutions dropdown list do the following
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;//Displays the resolution in the width by height format
            options.Add(option);// adds the resolution to the list

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)// if an available resolution is the same as the users current scrren width adn height then perform the following
            {
                CurrentRes = i;// assignes the current resolution to resolution dropdown value 
            }
        }
        ResDrop.AddOptions(options);//Adds the list of resolitions tothe resolution drop down values
        ResDrop.value = CurrentRes;// Sets the default resolution of the user to the currently selected resolution
        ResDrop.RefreshShownValue();// refreshes the list for the resolution dropdown
    }
    public void SetResolution(int ResIndex)
    {
        Resolution resolution = resolutions[ResIndex];// Sets the value for the desired resolution to a resolution index in the resolution array
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);// sets the current screen resolution
    }
    public void setBrightness(float brightness)
    {
        RenderSettings.ambientLight = new Color(brightness, brightness, brightness, 1);//Will set the brightness based on the user slider settings
        PlayerPrefs.SetFloat("UserBrightness", brightness);// will store the brightness settigns inside a playerpref location to be loaded into the main scene when the player progresses 
    }
    public void fullscreen(bool isFull)
    {
        Screen.fullScreen = isFull;// if this function is called then the view type is set to fullscreen
    }

}
