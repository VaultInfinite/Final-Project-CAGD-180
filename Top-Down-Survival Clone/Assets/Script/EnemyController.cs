/*
 * Salmoria, Wyatt & Aquino, Vicky
 * 12/8/23
 * This script controls the enemy navigation
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //Designation for the coin; allows the enemy to drop coins upon bullet contact.
    public GameObject coinPrefab;
    //Designation for the crate; random spawn that when destroyed contains a random number of coins.
    public GameObject cratePrefab;
    // get the player's gameobject.
    public GameObject player;
    // control the speed of this enemy.
    public float speed;
    // check how far away the player is.
    public float distance;
    // this is how much damage this enemy will do if attacking the player.
    public int damage;
    // this is how much health the enemy will have.
    public int health;

    private MeshRenderer[] children;

    private void Start()
    {
        //Grabs every single child of the gameobject and places them into an array; utilized to make enemy flash when taking damage, and not dying.
        children = GetComponentsInChildren<MeshRenderer>();
    }

    private void Update()
    {
        // constantly look at the player using its transform.
        this.gameObject.transform.LookAt(player.transform);
        // set the distance variable to the distance between this gameObject and the player
        distance = Vector3.Distance(transform.position, player.transform.position);
        // find the direction the player is in
        Vector3 direction = player.transform.position - transform.position;

        //Additions by Wyatt; Lets the mouse stay on the ground properly instead of floating up to the Player's y position and casting a strange shadow.
        Vector3 PlayerPosition = player.transform.position;
        //PlayerPosition.Scale(new Vector3(1f,0f,1f));
        PlayerPosition.y -= 0.75f;

        // move towards the player using the player's position
        transform.position = Vector3.MoveTowards(this.transform.position, PlayerPosition, speed * Time.deltaTime);
    }
    /// <summary>
    /// If the enemy gets hit by a bullet this is called. If the enemy health goes below zero, it will die and add a number to the enemy killed count.
    /// </summary>
    /// <param name="damage">The damage dealt by the player bullet.</param>
    public void DamageEnemy(int damage)
    {
        StartCoroutine(Blink());
        health -= damage;
        if (health <= 0)
        {
            //A random number from 0 to 1 for crateChance.
            float crateChance = Random.value;
            //If float number that was randomly chosen is above .95, a 5% chance, then a crate will spawn on the enemy.
            if (crateChance >= 0.95f)
            {
                GameObject CrateInstance = Instantiate(cratePrefab, transform.position, new Quaternion());
            }
            //If float number is less than .95, a 95% chance, then a coin will spawn.
            else
            {
                GameObject CoinInstance = Instantiate(coinPrefab, transform.position, new Quaternion());
            }
            // add one to the player's kill count variable then destroy this gameObject
            player.GetComponent<PlayerController>().addEnemyKilled();
            Destroy(this.gameObject);
        }
    }
    //When started in the damageenemy function, will make all meshrenderer's of the enemy turn off and on.
    IEnumerator Blink()
    {
        for (int i = 0; i < 4; i++)
        {
            //For each item in the array, toggle its meshrenderer off and on.
            foreach (MeshRenderer child in children)
            {
                child.enabled = !child.enabled;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
