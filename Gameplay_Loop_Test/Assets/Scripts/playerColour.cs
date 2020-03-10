using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player1Colour : MonoBehaviour
{
    public Material red;
    public Material blue;
    public Material green;
    public Material yellow;
    public static string p1Colour = "grey";
    private void OnTriggerStay(Collider obeliskSphere)
    {
        if(obeliskSphere.tag == "obelisk" && p1Colour == "grey")
        {
            GameObject.Find("E1").GetComponent<MeshRenderer>().enabled = true;
            if (obeliskSphere.name == "redSphere" && Input.GetButton("xButton"))
            {
                this.gameObject.GetComponent<MeshRenderer>().material = red;
                p1Colour = "red";
                gameStarter.readyPlayers++;
                disableObelisk();
            }
            if (obeliskSphere.name == "blueSphere" && Input.GetButton("xButton"))
            {
                this.gameObject.GetComponent<MeshRenderer>().material = blue;
                p1Colour = "blue";
                gameStarter.readyPlayers++;
                disableObelisk();
            }
            if (obeliskSphere.name == "greenSphere" && Input.GetButton("xButton"))      
            {
                this.gameObject.GetComponent<MeshRenderer>().material = green;
                p1Colour = "green";
                gameStarter.readyPlayers++;
                disableObelisk();
            }
            if (obeliskSphere.name == "yellowSphere" && Input.GetButton("xButton"))
            {
                this.gameObject.GetComponent<MeshRenderer>().material = yellow;
                p1Colour = "yellow";
                gameStarter.readyPlayers++;
                disableObelisk();
            }
            void disableObelisk()
            {
                obeliskSphere.GetComponent<SphereCollider>().enabled = false;
                obeliskSphere.GetComponent<MeshRenderer>().enabled = false;
                GameObject.Find("E1").GetComponent<MeshRenderer>().enabled = false;
                obeliskSphere.GetComponentInChildren<Light>().enabled = false;
            }
        }
    }

    private void OnTriggerExit(Collider obeliskSphere)
    {
        GameObject.Find("E1").GetComponent<MeshRenderer>().enabled = false;
    }
}
