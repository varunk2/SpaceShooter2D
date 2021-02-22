using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrollerController : MonoBehaviour
{
    public Transform Background1, Background2;
    public float scrollSpeed;

    private float _backgroundWidth; 

    void Start()
    {
        _backgroundWidth = Background1.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
    }

    void Update() {
        Movement();
    }

    private void Movement() {
        float newBackgroundPositionX = scrollSpeed * Time.deltaTime;
        Background1.position -= new Vector3(newBackgroundPositionX, 0f, 0f);
        Background2.position -= new Vector3(newBackgroundPositionX, 0f, 0f);

        if (Background1.position.x < -_backgroundWidth - 1) {
            Background1.position += new Vector3(_backgroundWidth * 2f, 0f, 0f);
        }

        if (Background2.position.x < -_backgroundWidth - 1) {
            Background2.position += new Vector3(_backgroundWidth * 2f, 0f, 0f);
        }
    }
}
