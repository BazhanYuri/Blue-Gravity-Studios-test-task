using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerInventoryHolder
{
    private IInventory _inventory;
    private IPlayerInput _playerInput;



    public PlayerInventoryHolder(IInventory inventory, IPlayerInput playerInput)
    {
        _inventory = inventory;
        _playerInput = playerInput;
    }

    public void Initialize()
    {
        _playerInput.InventoryButtonPressed += OnInventoryButtonPressed;
    }

    private void OnInventoryButtonPressed()
    {
        if (_inventory.IsInventoryVisible)
        {
            _inventory.HideInventory();
        }
        else
        {
            _inventory.ShowInventory();
        }
    }

}
