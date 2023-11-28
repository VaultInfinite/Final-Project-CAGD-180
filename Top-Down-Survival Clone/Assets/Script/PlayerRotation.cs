/*
 * 
 * 
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public bool facingRight;
    public bool facingForward;
    public bool facingLeft;
    public bool facingBack;

    // Update is called once per frame
    void Update()
    {
        rotate();
    }

    /// <summary>
    /// Controls the rotation and orientation of the player model.
    /// </summary>
    public void rotate()
    {
        Vector3 LookDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
        {
            LookDirection += Vector3.left;
        }
        if (Input.GetKey(KeyCode.W))
        {
            LookDirection += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            LookDirection += Vector3.back;
        }
        if (Input.GetKey(KeyCode.D))
        {
            LookDirection += Vector3.right;
        }
        if (LookDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(LookDirection);
        }

        //if (Input.GetKeyDown(KeyCode.A) && facingForward == true)
        //{
        //    transform.Rotate(Vector3.up * -90);
        //    facingForward = false;
        //    facingLeft = true;
        //}
        //if (Input.GetKeyDown(KeyCode.A) && facingRight == true)
        //{
        //    transform.Rotate(Vector3.up * 180);
        //    facingRight = false;
        //    facingLeft = true;
        //}
        //if (Input.GetKeyDown(KeyCode.A) && facingBack == true)
        //{
        //    transform.Rotate(Vector3.up * 90);
        //    facingBack = false;
        //    facingLeft = true;
        //}
        //if (Input.GetKeyDown(KeyCode.D) && facingForward == true)
        //{
        //    transform.Rotate(Vector3.up * 90);
        //    facingForward = false;
        //    facingRight = true;
        //}
        //if (Input.GetKeyDown(KeyCode.D) && facingLeft == true)
        //{
        //    transform.Rotate(Vector3.up * 180);
        //    facingLeft = false;
        //    facingRight = true;
        //}
        //if (Input.GetKeyDown(KeyCode.D) && facingBack == true)
        //{
        //    transform.Rotate(Vector3.up * -90);
        //    facingRight = false;
        //    facingRight = true;
        //}
        //if (Input.GetKeyDown(KeyCode.W) && facingRight == true)
        //{
        //    transform.Rotate(Vector3.up * -90);
        //    facingRight = false;
        //    facingForward = true;
        //}
        //if (Input.GetKeyDown(KeyCode.W) && facingLeft == true)
        //{
        //    transform.Rotate(Vector3.up * 90);
        //    facingLeft = false;
        //    facingForward = true;
        //}
        //if (Input.GetKeyDown(KeyCode.W) && facingBack == true)
        //{
        //    transform.Rotate(Vector3.up * 180);
        //    facingBack = false;
        //    facingForward = true;
        //}
        //if (Input.GetKeyDown(KeyCode.S) && facingRight == true)
        //{
        //    transform.Rotate(Vector3.up * 90);
        //    facingRight = false;
        //    facingBack = true;
        //}
        //if (Input.GetKeyDown(KeyCode.S) && facingLeft == true)
        //{
        //    transform.Rotate(Vector3.up * -90);
        //    facingLeft = false;
        //    facingBack = true;
        //}
        //if (Input.GetKeyDown(KeyCode.S) && facingForward == true)
        //{
        //    transform.Rotate(Vector3.up * 180);
        //    facingForward = false;
        //    facingBack = true;
        //}
    }
}
