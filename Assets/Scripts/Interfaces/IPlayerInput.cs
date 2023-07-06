using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public interface IPlayerInput
{
    public event Action<Vector2> PlayerMoved;
    public event Action InventoryButtonPressed;
    public event Action InteractButtonPressed;
    void InvokePlayerMoved(Vector2 value);
    void InvokeInventoryPressed(InputAction.CallbackContext context);
    void InvokeInteractButtonPressed(InputAction.CallbackContext context);
}
