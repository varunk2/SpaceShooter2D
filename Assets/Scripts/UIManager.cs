using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject gameOverScreen;

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

}
