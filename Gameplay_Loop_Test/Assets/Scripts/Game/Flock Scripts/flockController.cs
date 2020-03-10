﻿using UnityEngine;
using System.Collections;

public class flockController : MonoBehaviour
{
    public float minVelocity = 5;
    public float maxVelocity = 20;
    public float randomness = 1;
    public int flockSize;
    public GameObject footSoldier;
    public GameObject bannerMan;
    public GameObject shaman;
    public GameObject chase;
    public Material red;
    public Material blue;
    public Material green;
    public Material yellow;
    private Material colour;
    public int difficulty;

    public int BannerMen;
    public int Shamen;
    public Vector3 swarmCenter;
    public Vector3 swarmVelocity;

    private GameObject[] boids;

    void Start()
    {
        int x = Random.Range(1, 5);
        if(x == 1)
        {
            colour = red;

        }
        else if(x == 2)
        {
            colour = blue;
        }
        else if(x == 3)
        {
            colour = green;
        }
        else if(x == 4)
        {
            colour = yellow;
        }
        chase = GameObject.Find("Player1");
        flockSize = difficulty * 20;
        Shamen = difficulty - 1;
        BannerMen = difficulty;
        Debug.Log(minVelocity);
        Debug.Log(maxVelocity);
        maxVelocity = maxVelocity + (0.5f * BannerMen);
        minVelocity = minVelocity + (0.5f * BannerMen);
        Debug.Log(minVelocity);
        Debug.Log(maxVelocity);
        BannerMen = Random.Range(0, 4);
        Shamen = Random.Range(0, 2);
        boids = new GameObject[flockSize];
        for (var i = 0; i < (flockSize - BannerMen - Shamen); i++)
        {
            Vector3 position = new Vector3(
                Random.value * GetComponent<Collider>().bounds.extents.x,
                0,
                Random.value * GetComponent<Collider>().bounds.extents.z
            ) - GetComponent<Collider>().bounds.extents;

            GameObject boid = Instantiate(footSoldier, transform.position, transform.rotation) as GameObject;
            boid.transform.parent = transform;
            boid.transform.localPosition = position;
            boid.GetComponent<flockBehavior>().SetController(gameObject);
            Renderer[] children;
            children = boid.GetComponentsInChildren<Renderer>();
            foreach (Renderer renderer in children)
            {
                var materials = new Material[renderer.materials.Length];
                for (var j = 0; j < renderer.materials.Length; j++)
                {
                    materials[j] = colour;
                }
                renderer.materials = materials;
            }
            boid.GetComponent<MeshRenderer>().material = colour;
            boid.GetComponentInChildren<MeshRenderer>().material = colour;
            boids[i] = boid;
            boid.name = "footSoldier " + i;
        }
        for (var i = 0; i < BannerMen; i++)
        {
            Vector3 position = new Vector3(
                Random.value * GetComponent<Collider>().bounds.extents.x,
                0,
                Random.value * GetComponent<Collider>().bounds.extents.z
            ) - GetComponent<Collider>().bounds.extents;

            GameObject boid = Instantiate(bannerMan, transform.position, transform.rotation) as GameObject;
            boid.transform.parent = transform;
            boid.transform.localPosition = position;
            boid.GetComponent<flockBehavior>().SetController(gameObject);
            Renderer[] children;
            children = boid.GetComponentsInChildren<Renderer>();
            foreach (Renderer renderer in children)
            {
                var materials = new Material[renderer.materials.Length];
                for (var j = 0; j < renderer.materials.Length; j++)
                {
                    materials[j] = colour;
                }
                renderer.materials = materials;
            }
            boid.GetComponent<MeshRenderer>().material = colour;
            boid.GetComponentInChildren<MeshRenderer>().material = colour;
            boids[i] = boid;
            boid.name = "bannerMan " + i;
        }
        for (var i = 0; i < Shamen; i++)
        {
            Vector3 position = new Vector3(
                Random.value * GetComponent<Collider>().bounds.extents.x,
                0,
                Random.value * GetComponent<Collider>().bounds.extents.z
            ) - GetComponent<Collider>().bounds.extents;

            GameObject boid = Instantiate(shaman, transform.position, transform.rotation) as GameObject;
            boid.transform.parent = transform;
            boid.transform.localPosition = position;
            boid.GetComponent<flockBehavior>().SetController(gameObject);
            Renderer[] children;
            children = boid.GetComponentsInChildren<Renderer>();
            foreach (Renderer renderer in children)
            {
                var materials = new Material[renderer.materials.Length];
                for (var j = 0; j < renderer.materials.Length; j++)
                {
                    materials[j] = colour;
                }
                renderer.materials = materials;
            }
            boid.GetComponent<MeshRenderer>().material = colour;
            boid.GetComponentInChildren<MeshRenderer>().material = colour;
            boids[i] = boid;
            boid.name = "Shaman " + i;
        }
    }



//This isn't functional and will be removed if i cannot fix it.


 //    void Update()
 //    {
 //        Vector3 theCenter = Vector3.zero;
 //        Vector3 theVelocity = Vector3.zero;
// 
 //        foreach (GameObject boid in boids)
 //        {
 //            theCenter = theCenter + boid.transform.localPosition;
 //            theVelocity = theVelocity + GetComponent<Rigidbody>().velocity;
 //        }
//
 //        swarmCenter = theCenter / (flockSize);
 //        swarmVelocity = theVelocity / (flockSize);
 //    }
}
