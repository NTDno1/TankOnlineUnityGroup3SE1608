using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f; // Tốc độ di chuyển của enemy

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Di chuyển enemy theo hướng ngang (trục x)
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }


}
