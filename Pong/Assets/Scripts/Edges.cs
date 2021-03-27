using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edges : MonoBehaviour {
    EventManager eventManager;

    void Awake() {
        eventManager = FindObjectOfType<EventManager>();
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ball") {
            float y = collision.gameObject.transform.position.y;

            float screenHalfHeight = Camera.main.orthographicSize;

            if (y > screenHalfHeight) {
                eventManager.BallLeftTop?.Invoke(collision.gameObject);
            }

            if (y < -screenHalfHeight) {
                eventManager.BallLeftBottom?.Invoke(collision.gameObject);
            }
        }
    }
}
