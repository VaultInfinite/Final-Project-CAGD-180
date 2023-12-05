/*
 * Aquino, Vicky & Salmoria, Wyatt 
 * 11/30/23
 * Allows the coin to rotate to make it more appealing from a gameplay sense.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotate : MonoBehaviour
{
    //speed designation for the coin; how fast it rotates
    public int speed;

    // Update is called once per frame
    void Update()
    {
        //rotation code for the coin, the axis it rotates on.
        transform.Rotate(new Vector3(0, 45, 0) * Time.deltaTime * speed);
    }
}
