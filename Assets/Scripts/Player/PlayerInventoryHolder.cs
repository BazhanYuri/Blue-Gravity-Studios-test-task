using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerInventoryHolder
{
    private IInventory _inventory;
    private IPlayerInput _playerInput;

    private InventoryItem _inventoryItem;


    public PlayerInventoryHolder(IInventory inventory, IPlayerInput playerInput)
    {
        _inventory = inventory;
        _playerInput = playerInput;
    }

    public void Initialize()
    {
        _playerInput.InventoryButtonPressed += OnInventoryButtonPressed;

        InventoryItem.ItemDragged += OnItemDraged;
        InventoryItem.ItemNotDragged += OnItemNotDraged;
        ItemCell.ItemDroped += OnItemCellPointerUped;
    }



    public void Tick()
    {
        if (_inventoryItem != null)
        {
            _inventoryItem.transform.position = Input.mousePosition;
        }
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
    private void OnItemDraged(InventoryItem inventoryItem)
    {
        if (_inventoryItem != null)
        {
            return;
        }
        _inventoryItem = inventoryItem;
        _inventoryItem.transform.parent = _inventory.Content;

    }
    private void OnItemNotDraged()
    {
        MoveItemBack();
    }

    private void OnItemCellPointerUped(ItemCell cell)
    {
        MoveItemToAnotherCell(cell);
    }
    private void MoveItemBack()
    {
        _inventoryItem.transform.DOMove(_inventoryItem.ItemCell.transform.position, 0.2f).OnComplete(() => _inventoryItem = null);
    }
    private void MoveItemToAnotherCell(ItemCell cell)
    {
        _inventoryItem.SetCell(cell);
        _inventoryItem.transform.DORewind();
        MoveItemBack();
    }
}
