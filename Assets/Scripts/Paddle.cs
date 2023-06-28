using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private InputType inputType;
    [SerializeField] private float moveSpeed;
    private Rigidbody2D rb;

    private InputHandler inputHandler;
    private Vector2 moveDir;

    private void Awake()
    {
        inputHandler = gameObject.AddComponent<InputHandler>();
        inputHandler.InputType = inputType;

        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        inputHandler.OnKeyPressed += Move;
    }

    private void OnDisable()
    {
        inputHandler.OnKeyPressed -= Move;
    }

    private void Move(Vector2 dir)
    {
        moveDir = dir;
    }

    private void FixedUpdate()
    {
        //transform.position += (Vector3)moveDir * moveSpeed;
        rb.MovePosition(rb.position + moveDir * moveSpeed);
    }
}
