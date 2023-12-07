/*
 * Salmoria, Wyatt & Aquino, Vicky
 * 12/6/23
 * This script allows the enemies to spawn around the player outside of the player's view.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    //Designation for player to give to enemy spawns.
    public GameObject player;

    //Designations for the three standard enemy variants.
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    //Designation for the Boss enemy that will appear on the second level after reaching a certain score.
    public GameObject enemyBoss;

    void Start()
    {
        EnemySpawning();
    }

    private void EnemySpawning()
    {
        //The range for X & Z to allow the enemy to spawn in around the player.
        float x = Random.Range(-1.0f, 1.0f);
        float z = Random.Range(-1.0f, 1.0f);
        
        //Designation for the enemy positioning with newly assigned position numbers.
        Vector3 enemyPos = new Vector3(x, 0.0f, z);

        //Normalization of position in enemyPos.
        enemyPos.Normalize();

        //Check to see if enemy will spawn on player, fixes it by assigning the x a 1.0f value.
        if (enemyPos.magnitude < 0.5f)
        {
            enemyPos = Vector3.right;
        }

        //Multiplication of EnemyPos to take enemy off of player.
        enemyPos *= 9.0f;
        //Spawning of Enemy alongside addition of enemyPosition.
        GameObject EnemySpawn = Instantiate(enemy1, transform.position + enemyPos, transform.rotation);
        EnemySpawn.GetComponent<EnemyController>().player = player;
    }
}
