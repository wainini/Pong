using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class InputHandler : MonoBehaviour
{
    private InputType inputType;

    public InputType InputType 
    {
        get { return inputType; }
        set
        {
            inputType = value;
            if(inputType == InputType.Arrow)
            {
                assignedKey = AssignedKey.ArrowKeys;
            }
            else //if(InputType == InputType.WASD)
            {
                assignedKey = AssignedKey.WASDKeys;
            }
        }
    }

    private Dictionary<MoveDirection, KeyCode> assignedKey;

    public Action<Vector2> OnKeyPressed;

    private GameManager gm;

    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (assignedKey == null || gm.IsGameOver) return;

        Vector2 moveDir = Vector2.zero;

        if (Input.GetKey(assignedKey[MoveDirection.Up]))
        {
            moveDir += Vector2.up;
        }
        if (Input.GetKey(assignedKey[MoveDirection.Down]))
        {
            moveDir += Vector2.down;
        }

        OnKeyPressed?.Invoke(moveDir);
        
    }


}
