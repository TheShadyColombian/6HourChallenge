using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCollector : MonoBehaviour
{
    public float points = 10.0f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerStats.instance.AddPoints(points);
            Destroy(gameObject);
        }
    }
}