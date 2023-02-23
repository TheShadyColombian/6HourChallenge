using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBreak : MonoBehaviour {

    public float velocityMulti;

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player") {
            CameraShake.AddShake(PlayerController.instance.rb.velocity.magnitude * velocityMulti);
        }
    }

}