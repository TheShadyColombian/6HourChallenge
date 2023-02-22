using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float boostForce;
    public float boostChargeSpeed;
    public float forceCost;
    public float idleCost;
    public Color Movementcolor;
    public Color normalcolor;

    private PlayerStats stats;
    private Rigidbody2D rb;
    private Vector2 direction;
    private float boostCharge;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        stats = PlayerStats.instance;
    }

    void Update() {

        if (stats.movement > 0) {

            if (Input.GetMouseButtonDown(0)) {
                rb.velocity = Vector3.zero;
                boostCharge = 0;
            }

            if (Input.GetMouseButton(0)) {
                boostCharge += Time.deltaTime * boostChargeSpeed;
                MovementBarDisplay.instance.previewConsume = boostCharge;
            } else
                stats.movement -= Time.deltaTime * idleCost;

            if (Input.GetMouseButtonUp(0)) {
                //Calculate the direction to boost in based on the position of the cursor WHEN IT IS RELEASED!!!
                direction = Camera.main.ScreenToWorldPoint((Vector2)Input.mousePosition) - transform.position;
                direction = direction.normalized;

                rb.velocity = direction * boostForce * boostCharge;
                stats.movement -= boostCharge * forceCost;
                MovementBarDisplay.instance.previewConsume = 0;
            }

        }

    }

}