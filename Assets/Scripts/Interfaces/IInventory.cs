public interface IInventory
{
    public bool IsInventoryVisible { get; }
    void Initialize(int width, int height);
    void ShowInventory();
    void HideInventory();
    void AddItem(InventoryItem inventoryItem);
}