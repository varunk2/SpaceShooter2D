using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rigidBody;
    public Transform bottomLeftLimit, topRightLimit;

    public Transform shotPoint;
    public GameObject shot;
    // public GameObject playerExplosionEffect;

    public float timeBetweenShots = 0.1f;
    private float shotCounter;

    void Start(){}

    void Update() {
        ShipMovement();

        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }

        if (Input.GetButton("Fire1")) {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0) Shoot();
        }
    }

    private void ShipMovement() {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector2 movementVector = new Vector2(horizontal, vertical);
        rigidBody.velocity = movementVector * moveSpeed;

        float movementLimitsX = Mathf.Clamp(transform.position.x, bottomLeftLimit.position.x, topRightLimit.position.x);
        float movementLimitsY = Mathf.Clamp(transform.position.y, bottomLeftLimit.position.y, topRightLimit.position.y);
        transform.position = new Vector3(movementLimitsX, movementLimitsY, transform.position.z);       
    }

    private void Shoot() {
        Instantiate(shot, shotPoint.position, Quaternion.identity);

        shotCounter = timeBetweenShots;

        Debug.Log(shotCounter);
    }

    /*private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.GetComponent<MovingObjectsController>() != null) {
            Destroy(gameObject);
            Instantiate(playerExplosionEffect, transform.position, Quaternion.identity);
        }
    }*/
}
