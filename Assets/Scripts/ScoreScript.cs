using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public TMP_Text scoreText;

    private void Update()
    {
        scoreText.text = "Score: " + PlayerStats.instance.points.ToString();
    }
}