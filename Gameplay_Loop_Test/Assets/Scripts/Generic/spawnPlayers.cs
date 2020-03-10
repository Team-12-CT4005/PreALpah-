using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This script spawns in the players immediately.
public class spawnPlayers : MonoBehaviour
{
    public Transform spawnLight;
    commonEvents events = new commonEvents();
    private void Start()
    {
        events.initaliseLevel();
    }

}
