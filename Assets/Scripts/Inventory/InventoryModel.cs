using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryModel : MonoBehaviour, IInventory
{
    [SerializeField] private InventoryView _inventoryView;
    [SerializeField] private InventoryItem _inventoryItemPrefab;
    [SerializeField] private ItemCell _inventoryCellPrefab;

    private const int _StepSize = 75;

    private bool _isClosingAllowed = true;
    protected ItemCell[][] _itemCells;
    public bool IsInventoryVisible { get { return _inventoryView.IsVisible; } }
    public Transform Content => _inventoryView.ContentRoot;




    public void Initialize(int width, int height)
    {
        _itemCells = new ItemCell[width][];

        for (int i = 0; i < width; i++)
        {
            _itemCells[i] = new ItemCell[height];

            for (int j = 0; j < height; j++)
            {
                _itemCells[i][j] = Instantiate(_inventoryCellPrefab, _inventoryView.ContentRoot);
            }
        }
        SetSizeForRect();
    }


   

    int widthIndex = 0;
    int heightIndex = 0;


    public void AddItem(InventoryItem inventoryItem)
    {
        _itemCells[widthIndex][heightIndex].SetItem(inventoryItem);
        widthIndex++;

        if (widthIndex >= _itemCells.Length)
        {
            widthIndex = 0;
            heightIndex++;
        }
    }
    public void AddItemByConfigAt(int width, int height, InventoryItemConfig inventoryItemConfig)
    {
        InventoryItem newInventoryItem = Instantiate(_inventoryItemPrefab);
        newInventoryItem.Initialize(inventoryItemConfig, _itemCells[width][height]);

        _itemCells[width][height].SetItem(newInventoryItem);
    }


    public void HideInventory()
    {
        if (_isClosingAllowed == false)
        {
            return;
        }
        _inventoryView.Hide();
    }

    
    public void ShowInventory()
    {
        _inventoryView.Show();
    }
    public void BlockClose()
    {
        _inventoryView.CloseButton.gameObject.SetActive(false);
        _isClosingAllowed = false;
    }

    public void UnBlockCloose()
    {
        _inventoryView.CloseButton.gameObject.SetActive(true);
        _isClosingAllowed = true;
    }
    private void SetSizeForRect()
    {
        _inventoryView.ContentRoot.parent.GetComponent<RectTransform>().sizeDelta = new Vector2((_itemCells.Length + 2) * _StepSize,(_itemCells[0].Length + 2) * _StepSize);
    }

   
}
