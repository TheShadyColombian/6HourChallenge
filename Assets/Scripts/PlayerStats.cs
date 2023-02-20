using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;
    public float points = 0.0f;
    public float movementCoins = 0f;
    public float movementTokens = 5;

    private void Update()
    {
        if (movementTokens > 5)
        {
            movementTokens = 5;
        }
        if (movementTokens <= 0)
        {
            movementTokens = 0;
            GameManager.sharedInstance.GameOver();
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddPoints(float value)
    {
        points += value;
    }
    public void AddMovement()
    {
        movementTokens++;
    }
    public void MovementTokenUsed()
    {
        movementTokens--;
    }
}