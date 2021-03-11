using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int currentLives = 3;
    public float respawnTime = 2f;

    private void Awake() {
        instance = this;
    }

    public void KillPlayer() {
        currentLives--;
        
        if(currentLives > 0) {
            // Respawn Code
            StartCoroutine(RespawnCoroutine());
        } else {
            // Game Over Code
        }
    }

    public IEnumerator RespawnCoroutine() {
        yield return new WaitForSeconds(respawnTime);

        // Respawn Player
        HealthManagerController.instance.Respawn();

        WaveManager.instance.ContinueSpawning();
    }
}
