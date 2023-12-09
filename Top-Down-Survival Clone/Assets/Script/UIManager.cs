/*
 * Aquino, Vicky & Salmoria, Wyatt
 * 12/8/23
 * This script controls the UI elements of the game as well as scene management.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using TMPro;

public class UIManager : MonoBehaviour
{
    // Bool to check if the game is paused or not
    public bool IsPaused;
    // access the UI panel for the pauze screen
    public GameObject PausePanel;
    // access the health slider to show the player how much heath they have left
    public Slider HealthSlider;
    // access the player script
    public PlayerController PlayerScript;
    // Access the text variables to tell the player the neumerical values of their health, coin count, and how many enemies they've killed.
    public TextMeshProUGUI HealthText, coinsText, KillText;

    // Restart the game by loading scene 0
    public void startRestart()
    {
        SceneManager.LoadScene(0);
    }

    // Load scene one, which is the first scene
    public void Play()
    {
        SceneManager.LoadScene(1);
        ResumeGame();
    }

    //Load scene three, which is the second and final level.
    public void Advance()
    {
        SceneManager.LoadScene(3);
        ResumeGame();
    }

    // load the you lost scene
    public void LoseGame()
    {
        SceneManager.LoadScene(4);
    }

    // load the you won scene
    public void WinGame()
    {
        SceneManager.LoadScene(5);
    }

    // quit the game, close the application entirely
    public void quitGame()
    {
        Application.Quit();
    }

    // send the player to the instruction scene
    public void Instructions()
    {
        SceneManager.LoadScene(6);
    }

    private void Update()
    {
        // If we're in the main game scene called Final Scene, then check if the player hits escape
        if (this.gameObject.CompareTag("Pause"))
        {
            // if the game isn't paused and the player hits escape, pause the game
            if (Input.GetKeyDown(KeyCode.Escape) && !IsPaused)
            {
                PauseGame();
            } // If the game is paused and the player hits escape, resume the game
            else if (Input.GetKeyDown(KeyCode.Escape) && IsPaused)
            {
                ResumeGame();
            }
            // set the max of the health slider to the max of the player's health
            HealthSlider.maxValue = PlayerScript.healthLimit;
            // set the slider value to current health
            HealthSlider.value = PlayerScript.health;
            // change the text on top of the health slider to tell the player the numerical value of their health.
            HealthText.text = PlayerScript.health.ToString();
            // tell the player how many coins they've collected
            coinsText.text = "Coins: " + PlayerScript.coins.ToString();
            // tell the player how many enemies they've killed
            KillText.text = "Enemies Defeated: " + PlayerScript.EnemiesKilled.ToString();
            if (PlayerScript.health <= 0)
            {
                // if the player has zero or less health, call the LoseGame function
                LoseGame();
            }
        }
    }

    // Pause the game, freeze time, turn on the pause menu, free the player's mouse, and set IsPaused to true;
    public void PauseGame()
    {
        Time.timeScale = 0f;
        PausePanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        IsPaused = true;
    }

    // Resume the game, unfreeze time, turn off the pause menu, lock the player's mouse, and set IsPaused to false;
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        PausePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        IsPaused = false;
    }
}
