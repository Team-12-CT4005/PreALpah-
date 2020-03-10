using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingEvent : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator lightActivator()
    {
        yield return new WaitForSeconds(3);
        GameObject.Find("red Light").GetComponent<Light>().enabled = true;
        GameObject.Find("redSphere").GetComponent<MeshRenderer>().enabled = true;
        GameObject.Find("redSphere").GetComponent<SphereCollider>().enabled = true;
        yield return new WaitForSeconds(1);

        GameObject.Find("blue Light").GetComponent<Light>().enabled = true;
        GameObject.Find("blueSphere").GetComponent<MeshRenderer>().enabled = true;
        GameObject.Find("blueSphere").GetComponent<SphereCollider>().enabled = true;
        yield return new WaitForSeconds(1);

        GameObject.Find("green Light").GetComponent<Light>().enabled = true;
        GameObject.Find("greenSphere").GetComponent<MeshRenderer>().enabled = true;
        GameObject.Find("greenSphere").GetComponent<SphereCollider>().enabled = true;
        yield return new WaitForSeconds(1);

        GameObject.Find("yellow Light").GetComponent<Light>().enabled = true;
        GameObject.Find("yellowSphere").GetComponent<MeshRenderer>().enabled = true;
        GameObject.Find("yellowSphere").GetComponent<SphereCollider>().enabled = true;
    }

    void lightsOff()
    {
        GameObject.Find("red Light").GetComponent<Light>().enabled = false;
        GameObject.Find("redSphere").GetComponent<MeshRenderer>().enabled = false;
        GameObject.Find("redSphere").GetComponent<SphereCollider>().enabled = false;

        GameObject.Find("blue Light").GetComponent<Light>().enabled = false;
        GameObject.Find("blueSphere").GetComponent<MeshRenderer>().enabled = false;
        GameObject.Find("blueSphere").GetComponent<SphereCollider>().enabled = false;

        GameObject.Find("green Light").GetComponent<Light>().enabled = false;
        GameObject.Find("greenSphere").GetComponent<MeshRenderer>().enabled = false;
        GameObject.Find("greenSphere").GetComponent<SphereCollider>().enabled = false;

        GameObject.Find("yellow Light").GetComponent<Light>().enabled = false;
        GameObject.Find("yellowSphere").GetComponent<MeshRenderer>().enabled = false;
        GameObject.Find("yellowSphere").GetComponent<SphereCollider>().enabled = false;
    }
}
