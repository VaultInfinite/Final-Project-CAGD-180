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
    public GameObject player;

    public float speed;

    public float distance;

    public int damage;

    private void Update()
    {
        this.gameObject.transform.LookAt(player.transform);
        distance = Vector3.Distance(transform.position, player.transform.position);
        Vector3 direction = player.transform.position - transform.position;

        //Additions by Wyatt; Lets the mouse stay on the ground properly instead of floating up to the Player's y position and casting a strange shadow.
        Vector3 PlayerPosition = player.transform.position;
        //PlayerPosition.Scale(new Vector3(1f,0f,1f));
        PlayerPosition.y -= 0.75f;

        transform.position = Vector3.MoveTowards(this.transform.position, PlayerPosition, speed * Time.deltaTime);
    }

    public void KillEnemy()
    {
        player.GetComponent<PlayerController>().addEnemyKilled();
        Destroy(this.gameObject);
    }
}
