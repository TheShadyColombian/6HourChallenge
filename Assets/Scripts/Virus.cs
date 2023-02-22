using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : MonoBehaviour {

    public float boostDelay = 2;
    public float boostDelayVariation = 2;
    public float boostForce = 1;
    public float boostInaccuracyMagnitude = 1;
    public float scoreReward = 10;
    public float scorePenaltyOnRBCConsumption = 10;

    private Rigidbody2D rb;
    private float boostTimer;

    private void Start() {

        rb = GetComponent<Rigidbody2D>();

    }

    public void Update() {

        boostTimer -= Time.deltaTime;

        if (boostTimer < 0) {
            Boost();
            boostTimer = boostDelay + Random.Range(-boostDelayVariation, boostDelayVariation);
        }

    }

    void Boost() {

        Vector2 target = transform.position;

        if (RedBloodCell.instances.Count > 0) {
            //Find nearest RBC (default to first RBC)
            float nearestRBCDistance = Vector2.Distance(transform.position, RedBloodCell.instances[0].transform.position);
            int nearestRBCIndex = 0;
            for (int i = 1; i < RedBloodCell.instances.Count; i++) {
                float currentCandidateDistance = Vector2.Distance(transform.position, RedBloodCell.instances[i].transform.position);
                if (currentCandidateDistance < nearestRBCDistance) {
                    nearestRBCDistance = currentCandidateDistance;
                    nearestRBCIndex = i;
                }
            }
            target = RedBloodCell.instances[nearestRBCIndex].transform.position;
        }

        //Offset the target position by a random amount
        target += new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * boostInaccuracyMagnitude;

        rb.AddForce((target - (Vector2)transform.position).normalized * boostForce);

    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            PlayerStats.instance.AddPoints(scoreReward);
            Destroy(gameObject);
        }
        if (other.tag == "RedBloodCell") {
            PlayerStats.instance.SubtractPoints(scoreReward);
            Destroy(other.gameObject);
        }
    }

}