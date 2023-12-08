/*
 * Salmoria, Wyatt & Aquino, Vicky
 * 12/6/23
 * This script allows the enemies to spawn around the player outside of the player's view.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
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

    //Designation for the enemy spawning boolean that determines whether or not enemies will spawn.
    private bool enemySpawns = false;

    //Amount that the spawn enemies script will wait for; Will be changed through coins acquisition through 60 / spawntime = seconds.
    private float spawntime = 15f;

    //Designation for damage; allows damage of enemies to be changed in this script later through coins acquisition.
    public int damage;
    //Designation for speed; allows speed of enemies to be changed in this script later through coins acquisition.
    public float speed;

    void Start()
    {
        StartCoroutine(SpawnTime());
    }

    void Update()
    {
        if (enemySpawns == true)
        {
            EnemySpawning();
            EnemySpawning();
            EnemySpawning();
            EnemySpawning();
            StartCoroutine(SpawnTime());
        }
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

        //Random number generator that chooses which of the three mice models will be used to add variety to enemy appearance.
        
        int enemyModel = Random.Range(0, 3);
        GameObject Enemy = null;
        if (enemyModel == 0)
        {
            Enemy = enemy1;
        }
        if (enemyModel == 1)
        {
            Enemy = enemy2;
        }
        if (enemyModel == 2)
        {
            Enemy = enemy3;
        }

        //Multiplication of EnemyPos to take enemy off of player.
        enemyPos *= 9.0f;
        //Spawning of Enemy alongside addition of enemyPosition.
        GameObject EnemySpawn = Instantiate(Enemy, transform.position + enemyPos, transform.rotation);
        EnemySpawn.GetComponent<EnemyController>().player = player;
        EnemySpawn.GetComponent<EnemyController>().speed = speed;
        EnemySpawn.GetComponent<EnemyController>().damage = damage;
    }
    //Ienumerator for the spawntime of enemies; decides how often enemies will spawn.
    IEnumerator SpawnTime()
    {
        //Set Spawns for enemies to true; spawn a wave.
        enemySpawns = false;
        yield return new WaitForSeconds(60f / spawntime);
        //Set Spawns for enemies to false; wait before spawning another wave.
        enemySpawns = true;


    }
}
