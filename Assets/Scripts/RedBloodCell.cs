using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RDG;

public class RedBloodCell : MonoBehaviour {

    public float consumeShake = 1;

    public static List<RedBloodCell> instances { get; private set; } = new List<RedBloodCell>();

    public float movementRestorationAmount;

    public void Start() {

        if (!instances.Contains(this))
            instances.Add(this);

    }

    private void OnDestroy() {

        instances.Remove(this);

    }

    public void Update() {
        


    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            if (!PlayerController.instance.dead)
                PlayerStats.instance.movement += movementRestorationAmount;
            CameraShake.AddShake(consumeShake);
            CameraShake.HitFreeze();
            CameraShake.instance.StartCoroutine("PickupVibratePattern");
            Destroy(gameObject);
        }
    }

}