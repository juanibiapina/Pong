using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float speed;

    private Rigidbody2D body;

    void Awake() {
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        float input = Input.GetAxisRaw("Horizontal");

        body.velocity = Vector2.right * input * speed;
    }
}
