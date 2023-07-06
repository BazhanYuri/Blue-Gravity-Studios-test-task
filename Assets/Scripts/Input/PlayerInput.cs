using UnityEngine;
using System;
using Zenject;
using UnityEngine.InputSystem;

public class PlayerInput : IPlayerInput, IInitializable
{
    private MyInputActions _inputActions;


    public event Action<Vector2> PlayerMoved;
    public event Action InventoryButtonPressed;
    public event Action InteractButtonPressed;

    public void Initialize()
    {
        _inputActions  = new MyInputActions();
        _inputActions.Enable();
        _inputActions.Newactionmap.Movement.performed += OnMoved;
        _inputActions.Newactionmap.Movement.canceled += OnMoved;
        _inputActions.Newactionmap.Inventory.started += InvokeInventoryPressed;
    }

    private void OnMoved(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();

        InvokePlayerMoved(input);
    }

    public void InvokePlayerMoved(Vector2 value)
    {
        PlayerMoved?.Invoke(value);
    }

    public void InvokeInventoryPressed(InputAction.CallbackContext context)
    {
        InventoryButtonPressed?.Invoke();
    }

    public void InvokeInteractButtonPressed(InputAction.CallbackContext context)
    {
        InteractButtonPressed?.Invoke();
    }
}

