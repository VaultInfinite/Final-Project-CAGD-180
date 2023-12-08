/*
 * Salmoria, Wyatt & Aquino, Vicky
 * 12/05/23
 * This script controls the enemy navigation
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // get the player's gameobject
    public GameObject player;
    // control the speed of this enemy
    public float speed;
    // check how far away the player is
    public float distance;
    // this is how much damage this enemy will do if attacking the player
    public int damage;

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

    public void KillEnemy()
    {
        // add one to the player's kill count variable then destroy this gameObject
        player.GetComponent<PlayerController>().addEnemyKilled();
        Destroy(this.gameObject);
    }
}
