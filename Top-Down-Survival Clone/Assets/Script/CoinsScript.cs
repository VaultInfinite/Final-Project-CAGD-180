/*
 * Salmoria, Wyatt & Aquino, Vicky
 * 12/8/23
 * This script dictates the functionality of the coins; in esssence, it acts as the backbone of the entire game
 * by dictating many different aspects such as player damage and enemy count/variety, as well as level transitions.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinsScript : MonoBehaviour
{
    //Designation for the exterior scripts for the player and the enemyspawnscript.
    public PlayerController player;
    public EnemySpawnScript spawning;

    //Float for the amount of timeElapsed; used to constantly designate the amount of time passed, and helps decide when enemies spawn with more health and damage.
    private float timeElapsed = 0.0f;

    //Designation for whether or not the level the coinscript is within is the final(second) level or not.
    public bool secondLevel = false;
    //Designation for whether the final boss has spawned or not.
    private bool bossSpawn = false;

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        spawning.health = 1 + (int)timeElapsed / 40;
        spawning.damage = 1 + (int)timeElapsed / 20;

        //Coins variable to store the coins the player is picking up in the player script.
        int coins = player.coins;
        //Each if statement will do different things at different increments of coins; every 50, the player will be buffed.
        //Every 75, the amount of enemies will increase; 4+1*(the times spawning has increased) until a certain point.
        //The level will switch one time to the intermission scene at 600 coins, and spawn the boss at 750.
        //When the boss is defeated, The game will be over in victory.
        if (coins >= 50)
        {
            player.damage = 2;
            player.projectileSpeed = 4f;
            player.fireRate = 75;
            player.healthLimit = 110;
        }
        if (coins >= 75)
        {
            spawning.enemySpawnCount = 5;
        }
        if (coins >= 100)
        {
            player.damage = 3;
            player.speed = 4.25f;
            player.fireRate = 90;
            player.healthLimit = 120;
        }
        if (coins >= 150)
        {
            player.damage = 4;
            player.projectileSpeed = 5f;
            player.fireRate = 105;
            player.healthLimit = 130;
        }
        if (coins >= 175)
        {
            spawning.enemySpawnCount = 7;
        }
        if (coins >= 200)
        {
            player.damage = 5;
            player.speed = 4.5f;
            player.fireRate = 120;
            player.healthLimit = 140;
        }
        if (coins >= 250)
        {
            player.damage = 6;
            player.projectileSpeed = 6f;
            player.fireRate = 135;
            player.healthLimit = 150;
        }
        if (coins >= 275)
        {
            spawning.enemySpawnCount = 10;

        }
        if (coins >= 300)
        {
            player.damage = 7;
            player.speed = 4.75f;
            player.fireRate = 150;
            player.healthLimit = 160;
        }
        if (coins >= 350)
        {
            player.damage = 8;
            player.projectileSpeed = 7f;
            player.fireRate = 165;
            player.healthLimit = 170;
        }
        if (coins >= 375)
        {
            spawning.enemySpawnCount = 12;
        }
        if (coins >= 400)
        {
            player.damage = 9;
            player.speed = 5.0f;
            player.fireRate = 180;
            player.healthLimit = 180;
        }
        if (coins >= 450)
        {
            player.damage = 10;
            player.projectileSpeed = 8f;
            player.fireRate = 195;
            player.healthLimit = 190;
        }
        if (coins >= 475)
        {
            spawning.enemySpawnCount = 17;
        }
        if (coins >= 500)
        {
            player.speed = 6f;
        }
        if (coins >= 600 & secondLevel == false)
        {
            SceneManager.LoadScene(2);
        }
        if (coins >= 650)
        {
            player.damage = 15;
            player.speed = 7f;
            player.projectileSpeed = 10f;
            player.fireRate = 240;
            player.healthLimit = 200;
        }
        if (coins >= 675)
        {
            spawning.enemySpawnCount = 20;
        }
        //Once the coins reach this value, spawn the enemy boss mob with a set amount of health. Once this enemy is defeated, end the game with a victory. 
        if (coins >= 750 && bossSpawn == false)
        {
            bossSpawn = true;
            spawning.bossSpawning = true;
        }
    }
}
