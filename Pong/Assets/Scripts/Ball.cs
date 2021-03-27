using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public float maxSpeed = 20;

    Rigidbody2D body;

    void Awake() {
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        if (body.velocity.magnitude > maxSpeed) {
            body.velocity = Vector3.ClampMagnitude(body.velocity, maxSpeed);
        }
    }
}
