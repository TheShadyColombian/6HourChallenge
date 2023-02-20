using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTokensDisplay : MonoBehaviour
{
    public GameObject[] movementTokenIcons;

    private void Update()
    {
        int i = 0;
        while (i < movementTokenIcons.Length && i < PlayerStats.instance.movementTokens)
        {
            movementTokenIcons[i].SetActive(true);
            i++;
        }
        while (i < movementTokenIcons.Length)
        {
            movementTokenIcons[i].SetActive(false);
            i++;
        }
    }
}
