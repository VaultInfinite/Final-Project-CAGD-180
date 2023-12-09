/*
 * Salmoria, Wyatt & Aquino, Vicky
 * 12/8/23
 * This script controls the bullet movement and overall properties of the bullet.
 */
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // the variables to control the speed
    public float speed;
    // the variable to control how much damage the bullet does and how long it lasts before despawning
    public int damage, lifetime;

    private void OnTriggerEnter(Collider other)
    {
        // if the bullet hits an enemy call the killEnemy function from said enemy and then destroy it.
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyController>().DamageEnemy(damage);
        }
    }
    private void Start()
    {
        // start the despawn timer
        StartCoroutine(despawnTimer());  
    }

    private void Update()
    {
        // move the bullet forward
        transform.position += speed * Time.deltaTime * transform.forward;
    }


    IEnumerator despawnTimer()
    {
        // wait for x seconds (set by the lifetime variable) and then detroy this gameobject
        yield return new WaitForSeconds(lifetime);

        Destroy(gameObject);
    }
}
