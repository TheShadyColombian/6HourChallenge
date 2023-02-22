using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public static PlayerController instance;

    public Rigidbody2D rb { get; private set; }
    public bool dead { get; private set; }

    
    public float boostForce;
    public float boostChargeSpeed;
    public float forceCost;
    public float idleCost;
    public float virusBoostForce;
    public float trailOpacity;
    public Color Movementcolor;
    public Color normalcolor;

    private PlayerStats stats;
    private TrailRenderer tr;
    private GradientAlphaKey trailOpacityKey;
    private Vector2 direction;
    private float boostCharge;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponentInChildren<TrailRenderer>();
        stats = PlayerStats.instance;
        instance = this;
    }

    void Update() {

        if (stats.movement > 0) {

            dead = false;

            if (Input.GetMouseButtonDown(0)) {
                rb.velocity = Vector3.zero;
                boostCharge = 0;
            }

            if (Input.GetMouseButton(0)) {
                //Only keep charging if the current charge does not exceed the remaining movement energy
                if (boostCharge * forceCost < stats.movement)
                    boostCharge += Time.deltaTime * boostChargeSpeed;
                MovementBarDisplay.instance.previewConsume = boostCharge;
            } else
                stats.movement -= Time.deltaTime * idleCost;

            if (Input.GetMouseButtonUp(0))
                Launch();

        } else if (!dead) {
            Launch();
            dead = true;
        }

        trailOpacityKey = new GradientAlphaKey (rb.velocity.magnitude * trailOpacity / boostForce, 1);
        Gradient gradient = tr.colorGradient;
        gradient.SetKeys (tr.colorGradient.colorKeys, new GradientAlphaKey[] { new GradientAlphaKey(0, 0), trailOpacityKey });
        tr.colorGradient = gradient;

    }

    public void Launch () {

        //Calculate the direction to boost in based on the position of the cursor WHEN IT IS RELEASED!!!
        direction = Camera.main.ScreenToWorldPoint((Vector2)Input.mousePosition) - transform.position;
        direction = direction.normalized;

        rb.velocity = direction * boostForce * boostCharge;
        stats.movement -= boostCharge * forceCost;
        MovementBarDisplay.instance.previewConsume = 0;
    
    }

    public void VirusBoost() {
        rb.velocity += rb.velocity.normalized * virusBoostForce;
    }

}