/*
 * Salmoria, Wyatt & Aquino, Vicky
 * 11/16/23
 * This script controls the enemy navigation
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject player;

    public float speed;

    private float distance;

    private void Update()
    {
        this.gameObject.transform.LookAt(player.transform);
        distance = Vector3.Distance(transform.position, player.transform.position);
        Vector3 direction = player.transform.position - transform.position;

        transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
