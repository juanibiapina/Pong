using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public GameObject ballPrefab;

    public EdgeCollider2D edges;
    public Text scorePlayer;
    public Text scoreOpponent;

    public float ballSpeed = 5;

    EventManager eventManager;
    int playerScore = 0;
    int opponentScore = 0;

    void Awake() {
        eventManager = FindObjectOfType<EventManager>();
        eventManager.BallLeftTop += ScorePlayer;
        eventManager.BallLeftBottom += ScoreOpponent;

        UpdateScreenEdges();
    }

    void Start() {
        GameObject ball = Instantiate(ballPrefab, Vector3.zero, Quaternion.identity);
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.up * ballSpeed;
    }

    void Update() {
    }

    private void ScoreOpponent(GameObject ball) {
        Destroy(ball);
        opponentScore++;
        scoreOpponent.text = opponentScore.ToString();
    }

    private void ScorePlayer(GameObject ball) {
        Destroy(ball);
        playerScore++;
        scorePlayer.text = playerScore.ToString();
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
}
