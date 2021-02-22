using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjectsController : MonoBehaviour
{
    public float moveSpeed;

    void Update()
    {
        transform.position -= new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
    }

    private void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
