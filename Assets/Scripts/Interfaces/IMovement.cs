using System;
using UnityEngine;

public interface IMovement
{
    public event Action<Vector2> PlayerMoved;

    void Move(Vector2 value);
}
