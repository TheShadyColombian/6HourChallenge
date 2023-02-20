using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 direction;
    private Camera cam;
    public float force;
    private float forceMemory;
    public Color Movementcolor;
    public Color normalcolor;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        forceMemory = force;
        cam = Camera.main;
    }

    void Update()
    {
        if (PlayerStats.instance.movementTokens > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(0, 0, 0);
                cam.backgroundColor = Movementcolor;
                direction = (Vector2)Input.mousePosition - (Vector2)Camera.main.WorldToScreenPoint(transform.position);
                direction = direction.normalized;
            }

            if (Input.GetMouseButton(0))
            {
                force += Time.deltaTime * 10f;
            }

            if (Input.GetMouseButtonUp(0))
            {
                rb.AddForce(direction * force, ForceMode2D.Impulse);
                force = forceMemory;
                cam.backgroundColor = normalcolor;
                PlayerStats.instance.MovementTokenUsed();
            }
        }
    }
}