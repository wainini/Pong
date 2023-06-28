using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    public GameManager gm;
    
    private Rigidbody2D rb;

    private Vector2 moveDirection;
    public Vector2 MoveDirection
    {
        get
        {
            return moveDirection;
        }
        set
        {
            moveDirection = value;
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        MoveDirection = new Vector2(1, -1);
    }

    private void FixedUpdate()
    {
        if (gm.IsGameOver) return;
        rb.MovePosition(rb.position + MoveDirection * moveSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 contactDir = collision.GetContact(0).normal;

        if (contactDir.y == 0)
        {
            moveDirection.x = -MoveDirection.x;
        }
        else
        {
            moveDirection.y = -MoveDirection.y;
        }
    }

    public void DestroyBall()
    {
        gm.currentBall = null;
        Destroy(this.gameObject);
    }

}
