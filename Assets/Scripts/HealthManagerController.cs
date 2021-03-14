using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManagerController : MonoBehaviour
{
    public static HealthManagerController instance;

    public int currentHealth;
    public int maxHealth;

    public GameObject deathEffect;
    public AudioSource playerExplosionAudio;

    public float invincibleLength = 2f;
    private float _invincibleCounter;

    private SpriteRenderer _spriteRenderer;

    private void Awake() {
        instance = this;
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        Invincibility();
    }

    private void Invincibility() {
        if(_invincibleCounter >= 0) {
            _invincibleCounter -= Time.deltaTime;

            if(_invincibleCounter <= 0) {
                ChangePlayerInvincibilityColor(1f);
            }
        }
    }

    public void DamagePlayer() {
        if (_invincibleCounter <= 0) {
            currentHealth--;

            if (currentHealth < 0) {
                Instantiate(deathEffect, transform.position, Quaternion.identity);
                gameObject.SetActive(false);

                GameManager.instance.KillPlayer();
                WaveManager.instance.canSpawnWaves = false;
            }
        }
    }

    public void Respawn() {
        gameObject.SetActive(true);
        currentHealth = maxHealth;

        _invincibleCounter = invincibleLength;

        ChangePlayerInvincibilityColor(0.5f);
    }

    private void ChangePlayerInvincibilityColor(float alphaValue) {
        _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, alphaValue);
    }
}
