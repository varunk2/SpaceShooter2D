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

    void Update() {
        EnemyMovement();
    }

    private void EnemyMovement() {
        //transform.position -= new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);

        if (!shouldChangeDirection) {
            ChangeDirection(startDirection);
        } else {
            if(transform.position.x > changeDirectionXPoint) {
                ChangeDirection(startDirection);
            } else {
                ChangeDirection(changedDirection);
            }
        }
    }

    private void ChangeDirection(Vector2 direction) {
        float newMoveSpeedX = direction.x * moveSpeed * Time.deltaTime;
        float newMoveSpeedY = direction.y * moveSpeed * Time.deltaTime;
        float newMoveSpeedZ = 0f;
        transform.position += new Vector3(newMoveSpeedX, newMoveSpeedY, newMoveSpeedZ);
    }

    private void OnBecameInvisible() {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D otherGameObject) {
        if (otherGameObject.gameObject.GetComponent<PlayerController>() != null) {
            HealthManagerController.instance.DamagePlayer();
        }
    }
}
