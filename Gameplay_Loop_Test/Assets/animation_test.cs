using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation_test : MonoBehaviour
{
    Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        Anim.SetBool("ratRunning", true);
    }
}
