/*
 * Salmoria, Wyatt & Aquino, Vicky
 * 12/5/23
 * This script allows the player to control the player model via movement and fire weapons
 */
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Int that allows me to count the number of enemies Killed
    public int EnemiesKilled;

    public GameObject bulletPrefab;

    //Designations for the player model to allow the player to blink upon taking damage.
    public GameObject Body;
    public GameObject Tail1;
    public GameObject Tail2;
    public GameObject Tail3;
    public GameObject Tail4;
    public GameObject Tail5;
    public GameObject Ear1;
    public GameObject Ear2;
    public GameObject Eye1;
    public GameObject Eye2;
    public GameObject Iris1;
    public GameObject Iris2;
    public GameObject Nose;

    //The speed at which the player will move.
    public float speed = 5f;

    //The amount of health the player currently has at any point.
    public int health;

    //The amount of health the player can have maximum at any point.
    public int healthLimit;

    //The amount of coins the player has gained.
    public int coins;

    //The amount of damage the player deals.
    public int damage = 1;

    //The projectile speed of the player's weapon.
    public int projectileSpeed = 3; 

    //The fire rate of the player's weapon.
    public int fireRate;

    //location where the player respawns to.
    private Vector3 startPos;

    //Designation for Rigidbody for jumping.
    private Rigidbody rigidbody;

    //Designation for moving forward
    private bool movingForward;
    //Designation for moving left
    private bool movingLeft;
    //Designation for moving right
    private bool movingRight;
    //Designation for moving back
    private bool movingBack;

    //Designation for Invulnerability to help the player survive close encounters.
    private bool invuln = false;

    // Start is called before the first frame update
    void Start()
    {
        //set the startPos
        startPos = transform.position;
        //set the reference to the player's attached rigidbody
        rigidbody = GetComponent<Rigidbody>();
        EnemiesKilled = 0;
        coins = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Player movement
        if (Input.GetKey(KeyCode.W))
        {
            //translate the player forward by speed using time.deltatime
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            //translate the player left by speed using time.deltatime
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            //translate the player back by speed using time.deltatime
            transform.position += Vector3.back * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            //translate the player right by speed using time.deltatime
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        //player weapon
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerWeapon();
        }
    }

    /// <summary>
    /// This section dictates the fire rate of the player's weapon, the damage, and the target, all of which will be upgradeable via coin collection.
    /// </summary>
    private void PlayerWeapon()
    {
        GameObject target = TargetSelection();

        if (target == null)
        {
            return;
        }

        //Grabs the position of the player and the target.
        Vector3 position = transform.position;
        Vector3 targetPosition = target.transform.position;

        //Does the mathematics for the direction the bullet is required to travel.
        Vector3 direction = (targetPosition - position).normalized;

        //Spawns in the Bullet with position and rotation.
        GameObject bulletInstance = Instantiate(bulletPrefab, transform.position, Quaternion.LookRotation(direction));

        //Changes the variables of the bullet according to upgrades obtained.
        bulletInstance.GetComponent<Bullet>().speed = projectileSpeed;
        bulletInstance.GetComponent<Bullet>().damage = damage;
    }

    /// <summary>
    /// Decides which enemy needs to be targeted by taking the distance of each enemy in an array, comparing it to the enemy prior, and continuing until all enemies in the array are compared.
    /// </summary>
    private GameObject TargetSelection()
    {
        //Array for all the enemies to properly be found via tag.
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //Designation for the closest enemy as well as declaring it null at start.
        GameObject closestEnemy = null;
        //The distance of the closest enemy.
        float closestDist = 0;
        foreach (GameObject enemy in enemies)
        {
            //First run of this foreach loop, the program checks if closestenemy is null, and will assign the first enemy in the array to the position, as well as grab distance.
            if (closestEnemy == null)
            {
                closestEnemy = enemy;
                closestDist = closestEnemy.GetComponent<EnemyController>().distance;
            }
            //The distance of the enemy being compared to the currently logged closest enemy.
            float enemyCompare = 0;
            enemyCompare = enemy.GetComponent<EnemyController>().distance;
            if (closestDist >= enemyCompare)
            {
                closestDist = enemyCompare;
                closestEnemy = enemy;
            }
        }
        return closestEnemy;
    }

    /// <summary>
    /// The script that runs everything related to player damage; Invuln, blink, and check if health hits zero.
    /// </summary>
    private void Damage()
    {
        StartCoroutine(InvulnTimer());
        StartCoroutine(Blink());
        if (health <= 0)
        {
            //Swap scene here :)
            // This is done in UIManager
        }
    }
    
    /// <summary>
    /// Section of the script that runs collision; damage with enemies, picking up coins, etc.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        //If we collide with an enemy, take damage.
        if (other.gameObject.tag == "Enemy" && invuln == false)
        {
            health -= other.GetComponent<EnemyController>().damage;
            Damage();
        }
        //If we collide with a coin, pickup coin.
        if (other.gameObject.tag == "Coin")
        {
            other.gameObject.SetActive(false);
            coins += 1;
        }
    }


    //Enumerator for invulnerability, dictates whether or not the player will take damage when making contact.
    IEnumerator InvulnTimer()
    {
        //Set the invuln bool to true
        invuln = true;
        yield return new WaitForSeconds(0.5f);
        //Set invulnerability bool to false
        invuln = false;
    }
    //Ienumerator for the blinking of the player; allows the player to know when they take damage.
    IEnumerator Blink()
    {
        for (int index = 0; index < 2; index++)
        {
            if (index % 2 == 0)
            {
                //The list of meshrenderers that will be toggled; all tied to individual parts of model.
                Body.GetComponent<MeshRenderer>().enabled = false;
                Tail1.GetComponent<MeshRenderer>().enabled = false;
                Tail2.GetComponent<MeshRenderer>().enabled = false;
                Tail3.GetComponent<MeshRenderer>().enabled = false;
                Tail4.GetComponent<MeshRenderer>().enabled = false;
                Tail5.GetComponent<MeshRenderer>().enabled = false;
                Ear1.GetComponent<MeshRenderer>().enabled = false;
                Ear2.GetComponent<MeshRenderer>().enabled = false;
                Eye1.GetComponent<MeshRenderer>().enabled = false;
                Eye2.GetComponent<MeshRenderer>().enabled = false;
                Iris1.GetComponent<MeshRenderer>().enabled = false;
                Iris2.GetComponent<MeshRenderer>().enabled = false;
                Nose.GetComponent<MeshRenderer>().enabled = false;
            }
            else
            {
                //The list of meshrenderers that will be toggled; all tied to individual parts of model.
                Body.GetComponent<MeshRenderer>().enabled = true;
                Tail1.GetComponent<MeshRenderer>().enabled = true;
                Tail2.GetComponent<MeshRenderer>().enabled = true;
                Tail3.GetComponent<MeshRenderer>().enabled = true;
                Tail4.GetComponent<MeshRenderer>().enabled = true;
                Tail5.GetComponent<MeshRenderer>().enabled = true;
                Ear1.GetComponent<MeshRenderer>().enabled = true;
                Ear2.GetComponent<MeshRenderer>().enabled = true;
                Eye1.GetComponent<MeshRenderer>().enabled = true;
                Eye2.GetComponent<MeshRenderer>().enabled = true;
                Iris1.GetComponent<MeshRenderer>().enabled = true;
                Iris2.GetComponent<MeshRenderer>().enabled = true;
                Nose.GetComponent<MeshRenderer>().enabled = true;
            }
            yield return new WaitForSeconds(.5f);
        }
        //The list of meshrenderers that will be toggled; all tied to individual parts of model.
        Body.GetComponent<MeshRenderer>().enabled = true;
        Tail1.GetComponent<MeshRenderer>().enabled = true;
        Tail2.GetComponent<MeshRenderer>().enabled = true;
        Tail3.GetComponent<MeshRenderer>().enabled = true;
        Tail4.GetComponent<MeshRenderer>().enabled = true;
        Tail5.GetComponent<MeshRenderer>().enabled = true;
        Ear1.GetComponent<MeshRenderer>().enabled = true;
        Ear2.GetComponent<MeshRenderer>().enabled = true;
        Eye1.GetComponent<MeshRenderer>().enabled = true;
        Eye2.GetComponent<MeshRenderer>().enabled = true;
        Iris1.GetComponent<MeshRenderer>().enabled = true;
        Iris2.GetComponent<MeshRenderer>().enabled = true;
        Nose.GetComponent<MeshRenderer>().enabled = true;
    }


    public void addEnemyKilled()
    {
        EnemiesKilled++;
    }
}
