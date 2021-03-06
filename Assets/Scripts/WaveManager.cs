﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;
    public WaveObject[] waveObjects;
    
    public int currentWave;
    public float timeToNextWave;
    public bool canSpawnWaves;

    private void Awake() {
        instance = this;
    }

    void Start()
    {
        timeToNextWave = waveObjects[0].timeToSpawn;
    }

    void Update() {
        GenerateWaves();
    }

    private void GenerateWaves() {

        if (canSpawnWaves) {
            timeToNextWave -= Time.deltaTime;
            if (timeToNextWave <= 0) {
                Instantiate(waveObjects[currentWave].theWave, transform.position, transform.rotation);

                if (currentWave < waveObjects.Length - 1) {
                    currentWave++;

                    timeToNextWave = waveObjects[currentWave].timeToSpawn;
                } else {
                    ToggleWaves(false);
                }
            }
        }
    }

    public void ContinueSpawning() {
        if(currentWave < waveObjects.Length - 1 && timeToNextWave > 0) {
            ToggleWaves(true);
        }
    }

    public void ToggleWaves(bool toggle) {
        canSpawnWaves = toggle;
    }
}

[System.Serializable]
public class WaveObject {
    public float timeToSpawn;
    public EnemyWave theWave;
}
