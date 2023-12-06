/*
 * Aquino, Vicky & Salmoria, Wyatt
 * 11/27/23
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
    public bool IsPaused;
    public GameObject PausePanel;
    public Slider HealthSlider;
    public PlayerController PlayerScript;
    public TextMeshProUGUI HealthText, coinsText, KillText;

    public void startRestart()
    {
        SceneManager.LoadScene(0);
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void LoseGame()
    {
        SceneManager.LoadScene(2);
    }

    public void WinGame()
    {
        SceneManager.LoadScene(3);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void Instructions()
    {
        SceneManager.LoadScene(4);
    }

    private void Update()
    {
        if (this.gameObject.CompareTag("Pause"))
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !IsPaused)
            {
                PauseGame();
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && IsPaused)
            {
                ResumeGame();
            }
            HealthSlider.maxValue = PlayerScript.healthLimit;
            HealthSlider.value = PlayerScript.health;
            HealthText.text = PlayerScript.health.ToString();
            coinsText.text = "Coins: " + PlayerScript.coins.ToString();
            KillText.text = "Mice Killed: " + PlayerScript.EnemiesKilled.ToString();
            if (PlayerScript.health <= 0)
            {
                LoseGame();
            }
            if (PlayerScript.coins >= 30)
            {
                WinGame();
            }
            if (PlayerScript.EnemiesKilled >= 10)
            {
                WinGame();
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        PausePanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        IsPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        PausePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        IsPaused = false;
    }
}
