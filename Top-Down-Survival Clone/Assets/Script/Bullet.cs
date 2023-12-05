/*
 * Salmoria, Wyatt & Aquino, Vicky
 * 11/30/23
 * This script controls the bullet movement and overall properties of the bullet.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int damage, lifetime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Crate"))
        {
            other.gameObject.GetComponent<Crate>().dropCoins();
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            // do a thing
        }
    }
    private void Start()
    {
        StartCoroutine(despawnTimer());  
    }

    private void Update()
    {
        transform.position += speed * Time.deltaTime * transform.forward;
    }


    IEnumerator despawnTimer()
    {
        yield return new WaitForSeconds(lifetime);

        Destroy(gameObject);
    }
}
