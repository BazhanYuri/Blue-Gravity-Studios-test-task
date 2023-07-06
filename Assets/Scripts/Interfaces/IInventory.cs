using UnityEngine;

public interface IInventory
{
    public bool IsInventoryVisible { get; }
    public Transform Content { get; }

    void Initialize(int width, int height);
    void ShowInventory();
    void HideInventory();
    void AddItem(InventoryItem inventoryItem);
    void AddItemByConfigAt(int width, int height, InventoryItemConfig inventoryItemConfig);
}