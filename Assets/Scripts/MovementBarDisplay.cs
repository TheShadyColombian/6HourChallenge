using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Slider))]
public class MovementBarDisplay : MonoBehaviour {

    public static MovementBarDisplay instance;

    public float previewConsume;

    [Header("Components")]
    public RectTransform consumeRect;

    private Slider slider;
    private PlayerStats ps;

    // Start is called before the first frame update
    void Start() {

        instance = this;

        ps = PlayerStats.instance;

        slider = GetComponent<Slider>();

    }

    // Update is called once per frame
    void Update() {

        slider.value = Mathf.Max (0.0001f, ps.movement / ps.movementMax);

        consumeRect.anchorMin = Vector2.right * (1 - Mathf.Max (0.0001f, (previewConsume / (ps.movement))));
        consumeRect.offsetMin = Vector2.zero;

    }

}