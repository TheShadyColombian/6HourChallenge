using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public static PlayerController instance;

    public Rigidbody2D rb { get; private set; }
    public bool dead { get; private set; }

    [Header ("Movement Parameters")]
    public float boostChargeSpeed;
    public float boostForce;
    public float virusBoostForce;
    public float forceCost;
    public float idleCost;
    [Header ("Display Parameters")]
    public float trailOpacity;
    public float directionMinimumRadius;
    public float directionRadiusMultiplier;

    private PlayerStats stats;
    private TrailRenderer tr;
    private LineRenderer directionLineRenderer;
    private LineRenderer touchPointLineRenderer;
    private GradientAlphaKey trailOpacityKey;
    private Vector2 direction;
    private Vector2 velocityInsurance;
    private float boostCharge;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponentInChildren<TrailRenderer>();
        directionLineRenderer = GetComponent<LineRenderer>();
        touchPointLineRenderer = GetComponentsInChildren<LineRenderer>()[1];
        stats = PlayerStats.instance;
        instance = this;
    }

    void Update() {

        if (stats.movement > 0) {

            dead = false;

            if (Input.GetMouseButtonDown(0)) {
                velocityInsurance = rb.velocity;
                rb.velocity = Vector3.zero;
                boostCharge = 0;
            }

            if (Input.GetMouseButton(0)) {
                //Only keep charging if the current charge does not exceed the remaining movement energy
                if (boostCharge * forceCost < stats.movement)
                    boostCharge += Time.deltaTime * boostChargeSpeed;
                MovementBarDisplay.instance.previewConsume = boostCharge;
                touchPointLineRenderer.SetPositions(new Vector3[] {
                    transform.position,
                    (Vector2)Camera.main.ScreenToWorldPoint((Vector2)Input.mousePosition)
                });
                direction = Camera.main.ScreenToWorldPoint((Vector2)Input.mousePosition) - transform.position;
                directionLineRenderer.SetPositions(new Vector3[] {
                    (direction.normalized * directionMinimumRadius) + (Vector2) transform.position,
                    (direction.normalized * (directionMinimumRadius + (boostCharge * directionRadiusMultiplier))) + (Vector2) transform.position
                });
            } else
                stats.movement -= Time.deltaTime * idleCost;

            //Only launch if the player held the tap for more than 0.05 seconds, to avoid accidental taps or double taps that might cancel out the previous launch (happened a lot during testing)
            if (Input.GetMouseButtonUp(0))
                if (boostCharge > 0.05f)
                    Launch();
                else
                    //If the player accidentally performs a microclick, revert their velocity to what it was before to avoid players accidentally breaking from taps
                    rb.velocity = velocityInsurance;

        } else if (!dead) {
            Launch();
            dead = true;
        }

        bool enableLineRenderers = Input.GetMouseButton(0) && (stats.movement > 0);
        touchPointLineRenderer.widthMultiplier = Mathf.Lerp(touchPointLineRenderer.widthMultiplier, enableLineRenderers ? 0.6f  : 0, Time.deltaTime * 10);
        directionLineRenderer.widthMultiplier  = Mathf.Lerp(directionLineRenderer.widthMultiplier,  enableLineRenderers ? 0.05f : 0, Time.deltaTime * 10);
        

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