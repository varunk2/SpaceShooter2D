using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShotController : MonoBehaviour
{
    public float shotSpeed = 7f;
    public GameObject impactEffect;
    public GameObject objectExplosion;

    void Update()
    {
        transform.position += new Vector3(shotSpeed * Time.deltaTime, 0f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        MovingObjectsController spaceObjects = other.gameObject.GetComponent<MovingObjectsController>();
        EnemyController enemy = other.gameObject.GetComponent<EnemyController>();

        if (spaceObjects != null) {
            Instantiate(impactEffect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            Instantiate(objectExplosion, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        } else if (enemy != null) {
            Instantiate(impactEffect, transform.position, Quaternion.identity);
        }

    }

    private void OnBecameInvisible(){
        Destroy(gameObject);
    }
}
