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
    // grab the coin preab to use to spawn the coins
    public GameObject CoinPrefab;
    // get this object's crate to find the colliders to be used in the random coin spawning.
    public GameObject crate;


    private void OnTriggerEnter(Collider other)
    {
        // if a bullet collides with this crate, call drop coins and destroy the bullet, then this
        if (other.gameObject.CompareTag("Player"))
        {
            dropCoins();
            Destroy(gameObject);
        }
    }

    public void dropCoins()
    {
        // For as many coins this crate has, spawn a coin at a random point in the box collider.
        for (int i = 0; i < Random.Range(5, 21); i++)
        {
            GameObject temp = Instantiate(CoinPrefab);
            temp.transform.position = GetRandomPointInCollider(GetComponent<BoxCollider>());
        }
    }

    // this is a function to randomize a location within a collider, taking in the collider we wish to use for this generation
    Vector3 GetRandomPointInCollider(Collider collider)
    {
        // set the minimum and maxximum x, y, and z positions for something to spawn
        Vector3 point = new Vector3(Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            collider.transform.position.y, Random.Range(collider.bounds.min.z, collider.bounds.max.z));
        // if this point is different to the one just generated, set it to the new one
        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }
        // return point to be used
        return point;
    }
}
