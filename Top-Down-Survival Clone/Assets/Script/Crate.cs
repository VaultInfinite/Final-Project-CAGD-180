/*
 * Aquino, Vicky & Salmoria, Wyatt
 * 11/27/23
 * Controls the crate and dictates how many coins it contains.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    // variable to control how many coins to drop from the crate when destroyed
    public int CoinsContained;
    // grab the coin preab to use to spawn the coins
    public GameObject CoinPrefab;
    // get this object's crate to find the colliders to be used in the random coin spawning.
    public GameObject crate;


    private void OnTriggerEnter(Collider other)
    {
        // if a bullet collides with this crate, call drop coins and destroy the bullet, then this
        if (other.gameObject.CompareTag("Bullet"))
        {
            dropCoins();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    public void dropCoins()
    {
        // For as many coins this crate has, spawn a coin at a random point in the box collider, setting y to 1.
        for (int i = 0; i < CoinsContained; i++)
        {
            GameObject temp = Instantiate(CoinPrefab);
            temp.transform.position = GetRandomPointInCollider(GetComponent<BoxCollider>());
        }
        // once this for loop ends, disable all components of the crate
        crate.GetComponent<MeshRenderer>().enabled=false;
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
    }

    // this is a function to randomize a location within a collider, taking in the collider we wish to use for this generation
    Vector3 GetRandomPointInCollider(Collider collider)
    {
        // set the minimum and maxximum x, y, and z positions for something to spawn
        Vector3 point = new Vector3(Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y), Random.Range(collider.bounds.min.z, collider.bounds.max.z));
        // if this point is different to the one just generated, set it to the new one
        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }
        // set the y of said spawning point to 1;
        point.y = 1;
        // return point to be used
        return point;
    }
}
