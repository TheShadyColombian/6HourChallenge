using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBreak : MonoBehaviour
{
    private CameraShake cameraShake;
    public Camera cam;

    private void Start()
    {
        cameraShake = cam.gameObject.GetComponent<CameraShake>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
             StartCoroutine(cameraShake.Shake(0.25f, 0.1f));
        }
    }
}
