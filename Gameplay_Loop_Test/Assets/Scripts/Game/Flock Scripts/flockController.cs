using UnityEngine;
using System.Collections;

public class flockController : MonoBehaviour
{
    public float minVelocity = 5;
    public float maxVelocity = 12;
    public float randomness = 1;
    public int flockSize;

    public GameObject rat;
    public GameObject flagVarient;
    public GameObject chase;

    public int difficulty;

    public int Flags;
    public int Rats;
    public Vector3 swarmCenter;
    //public Vector3 swarmVelocity;

    private GameObject[] boids;

    void Start()
    {
        chase = GameObject.Find("Player1");
        flockSize = difficulty * 10;
        Flags = Random.Range(0, flockSize / 2);
        Rats = (flockSize - Flags);
        boids = new GameObject[flockSize];
        for (var i = 0; i < (Rats); i++)
        {
            Vector3 position = new Vector3(
                Random.value * GetComponent<Collider>().bounds.extents.x,
                0,
                Random.value * GetComponent<Collider>().bounds.extents.z
            ) - GetComponent<Collider>().bounds.extents;

            GameObject boid = Instantiate(rat, transform.position, transform.rotation) as GameObject;
            boid.transform.parent = transform;
            boid.transform.localPosition = position;
            boid.GetComponent<flockBehavior>().SetController(gameObject);
            boids[i] = boid;
            boid.name = "footSoldier " + i;
        }
        for (var i = 0; i < Flags; i++)
        {
            Vector3 position = new Vector3(
                Random.value * GetComponent<Collider>().bounds.extents.x,
                0,
                Random.value * GetComponent<Collider>().bounds.extents.z
            ) - GetComponent<Collider>().bounds.extents;

            GameObject boid = Instantiate(flagVarient, transform.position, transform.rotation) as GameObject;
            boid.transform.parent = transform;
            boid.transform.localPosition = position;
            boid.GetComponent<flockBehavior>().SetController(gameObject);
            boids[i] = boid;
            boid.name = "bannerMan " + i;
        }
    }
}
