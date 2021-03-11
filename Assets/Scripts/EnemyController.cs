using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;
    public Vector2 startDirection;

    public bool shouldChangeDirection;
    public float changeDirectionXPoint;
    public Vector2 changedDirection;

    public GameObject shotToFire;
    public Transform firePoint;
    public float timeBetweenShots;
    public bool canShoot;

    public int currentHealth;
    public GameObject deathEffect;

    private float _shotCounter;
    private bool _allowShooting;

    private void Start() {
        _shotCounter = timeBetweenShots;
    }

    void Update() {
        EnemyMovement();
    }

    private void EnemyMovement() {

        if (!shouldChangeDirection) {
            ChangeDirection(startDirection);
        } else {
            if(transform.position.x > changeDirectionXPoint) {
                ChangeDirection(startDirection);
            } else {
                ChangeDirection(changedDirection);
            }
        }

        if (_allowShooting) {
            _shotCounter -= Time.deltaTime;
            if (_shotCounter <= 0) Shoot();
        }
    }

    private void Shoot() {
        Instantiate(shotToFire, firePoint.position, Quaternion.identity);

        _shotCounter = timeBetweenShots;
    }

    private void ChangeDirection(Vector2 direction) {
        float newMoveSpeedX = direction.x * moveSpeed * Time.deltaTime;
        float newMoveSpeedY = direction.y * moveSpeed * Time.deltaTime;
        float newMoveSpeedZ = 0f;
        transform.position += new Vector3(newMoveSpeedX, newMoveSpeedY, newMoveSpeedZ);
    }

    public void DamageEnemy() {
        currentHealth--;
        if (currentHealth < 0) {
            Destroy(gameObject);
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }
    }

    private void OnBecameInvisible() {
        Destroy(gameObject);
    }

    private void OnBecameVisible() {
        if (canShoot) _allowShooting = true;
    }

    private void OnCollisionEnter2D(Collision2D otherGameObject) {
        if (otherGameObject.gameObject.GetComponent<PlayerController>() != null) {
            HealthManagerController.instance.DamagePlayer();
        }
    }
}
