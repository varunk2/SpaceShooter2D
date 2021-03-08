using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotsController : MonoBehaviour {
    public float shotSpeed = 7f;
    public GameObject impactEffect;

    void Update() {
        transform.position -= new Vector3(shotSpeed * Time.deltaTime, 0f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.GetComponent<PlayerController>() != null) {
            Instantiate(impactEffect, transform.position, Quaternion.identity);
            HealthManagerController.instance.DamagePlayer();
            Destroy(this.gameObject);
        }
    }

    private void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
