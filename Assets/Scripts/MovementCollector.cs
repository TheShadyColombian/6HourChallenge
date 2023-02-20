using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCollector : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerStats.instance.AddMovement();
            Destroy(gameObject);
        }
    }
}
