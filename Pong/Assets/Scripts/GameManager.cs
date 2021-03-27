using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject ball;
    public EdgeCollider2D edges;

    public float ballSpeed = 5;

    void Awake() {
        UpdateScreenEdges();
    }

    private void UpdateScreenEdges() {
        // calculate screen size
        float screenHalfWidth = Camera.main.aspect * Camera.main.orthographicSize;
        float screenHalfHeight = Camera.main.orthographicSize;

        // helper variables
        float w = screenHalfWidth;
        float h = screenHalfHeight + 1; // offset so bar goes out on bottom and top edges

        // calculate edges for collider
        List<Vector2> points = new List<Vector2>(4);
        points.Add(new Vector2(-w, h));
        points.Add(new Vector2(w, h));
        points.Add(new Vector2(w, -h));
        points.Add(new Vector2(-w, -h));
        points.Add(new Vector2(-w, h)); // close the loop
        edges.SetPoints(points);
    }

    void Start() {
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.down * ballSpeed;
    }

    void Update() {
    }
}
