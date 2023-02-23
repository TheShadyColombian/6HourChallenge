using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour { 

    public static CameraShake instance;

    public float shakeAmplitude;
    public float shakeDecay;
    public float shakeSpeed;

    private static float shake;
    private Color defaultBackgroundColour;

    private void Start() {
        instance = this;
        defaultBackgroundColour = Camera.main.backgroundColor;
    }

    public void Update() {

        shake = Mathf.Max(shake / (1 + (Time.unscaledDeltaTime * shakeDecay)), 0);

        transform.localPosition = new Vector2(
            Mathf.PerlinNoise(Time.unscaledTime * shakeSpeed, 0) - 0.4f, 
            Mathf.PerlinNoise(Time.unscaledTime * shakeSpeed, 100) - 0.4f
        ) * shakeAmplitude * shake;

        Camera.main.backgroundColor = Color.Lerp(Camera.main.backgroundColor, defaultBackgroundColour, Time.deltaTime * 2);

    }

    public static void AddShake (float amount) {

        shake += amount;

    }

    private IEnumerator HitFreezeCoroutine () {

        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(0.1f);
        Time.timeScale = 1;

    }

    public static void HitFreeze () {
        instance.StartCoroutine("HitFreezeCoroutine");
    }

}