using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject gameOverScreen;
    public Text livesText;
    public Slider healthBar;

    private void Awake() {
        instance = this;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetHealthBarValues(int currentHealth, int maxHealth) {
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
    }

    public void ChangeHealthBarValue(int currentHealth) {
        healthBar.value = currentHealth;
    }

    public void SetLives(int currentLives) {
        livesText.text = "x " + currentLives;
    }

    public void ToggleGameOverScreen(bool toggle) {
        gameOverScreen.SetActive(toggle);
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void QuitToMain() {

    }   

}
