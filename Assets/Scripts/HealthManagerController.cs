﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManagerController : MonoBehaviour
{
    public static HealthManagerController instance;

    public int currentHealth;
    public int maxHealth;

    public GameObject deathEffect;
    public AudioSource playerExplosionAudio;

    private void Awake() {
        instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        
    }

    public void DamagePlayer() {
        currentHealth--;

        if (currentHealth < 0) {
            //StartCoroutine(DeathEffect());
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }

    private IEnumerator DeathEffect() {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(playerExplosionAudio.clip.length);
        playerExplosionAudio.Play();
        gameObject.SetActive(false);
    }
}