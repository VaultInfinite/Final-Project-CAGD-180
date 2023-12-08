/*
 * Salmoria, Wyatt & Aquino, Vicky
 * 12/8/23
 * This script dictates the functionality of the coins; in esssence, it acts as the backbone of the entire game
 * by dictating many different aspects such as player damage and enemy count/variety, as well as level transitions.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsScript : MonoBehaviour
{
    //Designation for the exterior scripts for the player and the enemyspawnscript.
    public PlayerController player;
    public EnemySpawnScript spawning;

    //Coins variable to store the coins the player is picking up in the player script.
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int coins = player.coins;
    }
}
