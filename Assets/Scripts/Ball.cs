using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    
    private Rigidbody2D rb;
    private Vector2 moveDir;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        moveDir = new Vector2(1, -1);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDir * moveSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 contactDir = collision.GetContact(0).normal;

        if (contactDir.y == 0)
        {
            moveDir.x = -moveDir.x;
        }
        else
        {
            moveDir.y = -moveDir.y;
        }
    }
}
