using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public interface IPlayerInput
{
    public event Action<Vector2> PlayerMoved;
    public event Action InventoryButtonPressed;
    void InvokePlayerMoved(Vector2 value);
    void InvokeInventoryPressed(InputAction.CallbackContext context);
}
