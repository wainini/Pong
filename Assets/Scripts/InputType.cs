using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputType
{
    WASD,
    Arrow
}

public enum MoveDirection
{
    Up,
    Down
}

public static class AssignedKey
{
    public static Dictionary<MoveDirection, KeyCode> WASDKeys { get; private set; } = new Dictionary<MoveDirection, KeyCode>()
    {
        {MoveDirection.Up, KeyCode.W },
        {MoveDirection.Down, KeyCode.S }
    };

    public static Dictionary<MoveDirection, KeyCode> ArrowKeys { get; private set; } = new Dictionary<MoveDirection, KeyCode>()
    {
        {MoveDirection.Up, KeyCode.UpArrow },
        {MoveDirection.Down, KeyCode.DownArrow }
    };
}