/*
 * Salmoria, Wyatt & Aquino, Vicky
 * 11/16/23
 * This script allows the player to control the player model via movement, fire weapons, and 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //The speed at which the player will move.
    public float speed = 5f;

    //location where the player respawns to
    private Vector3 startPos;

    //Designation for Rigidbody for jumping.
    private Rigidbody rigidbody;

    //Designation for moving forward
    private bool movingForward;
    //Designation for moving left
    private bool movingLeft;
    //Designation for moving right
    private bool movingRight;
    //Designation for moving back
    private bool movingBack;

    // Start is called before the first frame update
    void Start()
    {
        //set the startPos
        startPos = transform.position;
        //set the reference to the player's attached rigidbody
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Player movement
        if (Input.GetKey(KeyCode.W))
        {
            //translate the player forward by speed using time.deltatime
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            //translate the player left by speed using time.deltatime
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            //translate the player back by speed using time.deltatime
            transform.position += Vector3.back * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            //translate the player right by speed using time.deltatime
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }
}
