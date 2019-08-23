using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA : MonoBehaviour
{
    Rigidbody2D rb;
    // Use this for initialization
    [SerializeField, Range(-1, 1)] int diretion;
    [SerializeField, Range(0, 1)] float distance;
    private bool inRange;
    [SerializeField] private LayerMask whatIsEnemy;
    [SerializeField] private float speed;
    public bool InRange
    {
        get { return inRange; }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (Physics2D.Raycast(new Vector2(transform.position.x, -0.18f), transform.right * diretion, distance, whatIsEnemy))
        {
            inRange = true;
        }
        else
        {
            inRange = false;
        }
        Move();
    }

    void Move()
    {
        if (!inRange)
            rb.velocity = new Vector2(Time.deltaTime * speed * diretion, rb.velocity.y);
    }
}
