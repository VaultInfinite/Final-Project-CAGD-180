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
    public TextMeshProUGUI HealthText;

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
