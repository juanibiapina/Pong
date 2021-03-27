using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opponent : MonoBehaviour {
    GameObject ball;
    Rigidbody2D body;

    void Awake() {
        body = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if (!ball) {
            ball = GameObject.FindGameObjectWithTag("Ball");
            if (!ball) {
                return;
            }
        }

        Vector2 target = new Vector2(ball.transform.position.x, transform.position.y);
        body.MovePosition(Vector2.MoveTowards(transform.position, target, Time.deltaTime * 40));
    }
}
