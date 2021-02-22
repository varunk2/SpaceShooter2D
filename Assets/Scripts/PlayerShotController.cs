using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShotController : MonoBehaviour
{
    public float shotSpeed = 7f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(shotSpeed * Time.deltaTime, 0f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.GetComponent<MovingObjectsController>() != null) {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }

    private void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
