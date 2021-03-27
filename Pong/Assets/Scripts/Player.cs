using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private Rigidbody2D body;

    float screenHalfWidth;

    void Awake() {
        body = GetComponent<Rigidbody2D>();
        screenHalfWidth = Camera.main.aspect * Camera.main.orthographicSize;
    }

    void Update() {
        float xScreen = Input.mousePosition.x;

        Vector2 pos = new Vector2(((2 * screenHalfWidth * xScreen) / Screen.width) - screenHalfWidth, transform.position.y);

        body.MovePosition(pos);

        float input = Input.GetAxis("Horizontal");
        body.MoveRotation(-35 * input);
    }
}
