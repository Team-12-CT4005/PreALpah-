using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleScript : MonoBehaviour
{
    public int maxHealth = 20;
    public int currentHealth;
    bool hit;
    bool ricoshet;
    public Health healthbar;
    public float timer;
    public void Start()
    {
        timer = 2.0f;
        
        //maxHealth = currentHealth;
        hit = false;
        ricoshet = false;

        int savedHealth = Health.CurrentHealth;
        if (savedHealth != 0)
        {
            currentHealth = savedHealth;
        }
        else
        {
            currentHealth = maxHealth;

        }
        healthbar.SetHealth(currentHealth);
    }             
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            hit = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        ricoshet = true;
    }
    void Update()
    {
        if (hit == true)
        {
            Damage(10);
            hit = false;               
        }

    }
    void Damage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
    }
}
