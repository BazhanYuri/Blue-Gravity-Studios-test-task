using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryModel : MonoBehaviour, IInventory
{
    [SerializeField] private InventoryView _inventoryView;
    [SerializeField] private InventoryItem _inventoryItemPrefab;

    private const int _StepSize = 150;

    private ItemCell[][] _itemCells;
    private InventoryItem[][] _items;
    public bool IsInventoryVisible { get { return _inventoryView.IsVisible; } }


    public void Initialize(int width, int height)
    {
        for (int i = 0; i < width * height; i++)
        {
            Instantiate(_inventoryItemPrefab, _inventoryView.ContentRoot);            
        }
        _itemCells = new ItemCell[width][];
        for (int i = 0; i < width; i++)
        {
            _itemCells[i] = new ItemCell[height];
        }

        SetSizeForRect();
    }

    public void AddItem(InventoryItem inventoryItem)
    {
        throw new System.NotImplementedException();
    }

    public void HideInventory()
    {
        _inventoryView.Hide();
    }

    
    public void ShowInventory()
    {
        _inventoryView.Show();
    }
    private void SetSizeForRect()
    {
        _inventoryView.ContentRoot.parent.GetComponent<RectTransform>().sizeDelta = new Vector2((_itemCells.Length + 1) * _StepSize, (_itemCells[0].Length + 1) * _StepSize);
    }
}
