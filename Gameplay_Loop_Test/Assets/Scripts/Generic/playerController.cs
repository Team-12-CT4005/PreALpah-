using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField]
    [Range(0.1f, 1f)]
    float speed = 0.3f;

    [SerializeField]
    [Range(1, 4)]
    int PlayerNumber = 1;

    int PlayerHealth = 10;
    bool takeDamage = true;

    public Transform Player;
    //The Transform of the player being controlled
    public Transform Target;
    //The Target is an invisible object at which the player looks at.

    //CONTROLS
    //LEFT JOYSTICK TO MOVE
    //RIGHT JOYSTICK TO LOOK AROUND

    // Update is called once per frame
    void Update()
    {
        PlayerNumber.ToString();
        //Look
        Vector3 inputDirection = Vector3.zero;
        inputDirection.x = Input.GetAxis("RightJoystickVertical" + PlayerNumber);
        inputDirection.z = Input.GetAxis("RightJoystickHorizontal" + PlayerNumber);
        inputDirection.Normalize();
        Target.transform.position = Player.position + inputDirection;
        //Move
        Vector3 moveVector = Vector3.zero;
        moveVector.x = Input.GetAxis("LeftJoystickVertical" + PlayerNumber);
        moveVector.z = Input.GetAxis("LeftJoystickHorizontal" + PlayerNumber);
        moveVector.Normalize();
        transform.position += moveVector * speed;
        transform.LookAt(Target);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "enemy")
        {
            if (takeDamage == true)
            {
                StartCoroutine("damageCooldown");
                damageRecoil(collision.transform);
                StartCoroutine("damageCooldown");
                PlayerHealth--;
                playersData playersdata = GameObject.Find("PlayerData").GetComponent<playersData>();
                playersdata.storeHealth(PlayerNumber, PlayerHealth);
            }
            if (takeDamage == false)
            {
                damageRecoil(collision.transform);
            }
        }
    }
    IEnumerator damageCooldown()
    {
        takeDamage = false;
        yield return new WaitForSeconds(0.3f);
        takeDamage = true;
    }
    private void damageRecoil(Transform enemyTransform)
    {
        //work in progress
    }
}