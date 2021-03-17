using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int currentLives;
    public float respawnTime = 2f;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        UIManager.instance.SetLives(currentLives);
    }

    public void KillPlayer() {
        currentLives--;
        UIManager.instance.SetLives(currentLives);


        if (currentLives > 0) {
            // Respawn Code
            StartCoroutine(RespawnCoroutine());
        } else {
            // Game Over Code
            UIManager.instance.ToggleGameOverScreen(true);
            //UIManager.instance.gameOverScreen.SetActive(true);
            WaveManager.instance.ToggleWaves(false);
        }
    }

    private IEnumerator RespawnCoroutine() {
        yield return new WaitForSeconds(respawnTime);

        // Respawn Player
        HealthManagerController.instance.Respawn();

        WaveManager.instance.ContinueSpawning();
    }
}
