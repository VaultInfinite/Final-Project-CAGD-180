/*
 * Salmoria, Wyatt & Aquino, Vicky
 * 11/28/23
 * This script controls the rotation of the player model to make them face the correct direction when pressing buttons.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
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
    }
}
