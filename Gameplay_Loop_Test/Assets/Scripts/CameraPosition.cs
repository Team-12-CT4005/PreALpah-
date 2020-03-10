using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public Transform Player1;
    public static int cameraAngle = 45;
    public static int cameraDisplacementY = 20;
    public static int cameraDisplacementX = 20;
    private Vector3 displacement = new Vector3(cameraDisplacementX, cameraDisplacementY, 0);
    private void Start()
    {
        this.transform.position = displacement;

    }
    private void Update()
    {
        this.transform.position = Player1.position + displacement;
    }
}
