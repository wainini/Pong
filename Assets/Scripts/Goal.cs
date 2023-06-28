using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Goal : MonoBehaviour
{
    [Range(0,1)]
    [Tooltip("0 is for RIGHT Goal, 1 is for LEFT Goal")]
    [SerializeField] private int goalNumber; 

    public Action<int> OnGoal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Ball>(out Ball ballScript))
        {
            ballScript.DestroyBall();
            OnGoal?.Invoke(goalNumber);
        }
    }
}
