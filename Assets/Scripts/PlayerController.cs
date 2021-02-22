using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rigidBody;
    public Transform bottomLeftLimit, topRightLimit;

    void Start()
    {
        
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector2 movementVector = new Vector2(horizontal, vertical);
        rigidBody.velocity = movementVector * moveSpeed;

        float movementLimitsX = Mathf.Clamp(transform.position.x,bottomLeftLimit.position.x, topRightLimit.position.x);
        float movementLimitsY = Mathf.Clamp(transform.position.y, bottomLeftLimit.position.y, topRightLimit.position.y);
        transform.position = new Vector3(movementLimitsX, movementLimitsY, transform.position.z);
    }
}
