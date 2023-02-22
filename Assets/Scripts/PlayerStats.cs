using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public static PlayerStats instance;
    public float score = 0.0f;
    public float movementMax = 5;
    public float movement;

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
        movement = movementMax;
    }

    private void Update() {
        if (movement > movementMax) {
            movement = movementMax;
        }
        if (movement <= 0) {
            movement = 0;
            GameManager.sharedInstance.GameOver();
        }
    }

    public void AddPoints(float value) {
        if (value < 0)
            Debug.LogError("Cannot add negative points. Use SubtractPoints(float) instead.");
        score += value;
    }
    public void SubtractPoints(float value) {
        if (value < 0)
            Debug.LogError("Cannot subtract negative points. Use AddPoints(float) instead.");
        score -= value;
    }



}