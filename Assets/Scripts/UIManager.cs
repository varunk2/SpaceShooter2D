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

    private void Awake() {
        instance = this;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ToggleGameOverScreen(bool toggle) {
        gameOverScreen.SetActive(toggle);
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void QuitToMain() {

    }

    public void SetLives(int currentLives) {
        livesText.text = "x " + currentLives;
    }

}
