using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyItemPopUp : PopUpWindow
{
    [SerializeField] private Button _buyButton;
    [SerializeField] private TextMeshProUGUI _priceText;

    private InventoryItem _inventoryItem;
    private IInventory _playerInventory;


    private void OnEnable()
    {
        _buyButton.onClick.AddListener(Buy);
        OnHidden += DestroyPopUp;
    }
    private void OnDisable()
    {
        _buyButton.onClick.RemoveListener(Buy);
        OnHidden -= DestroyPopUp;
    }

    public void Initialize(InventoryItem inventoryItem, IInventory playerInventory)
    {
        _inventoryItem = inventoryItem;
        _playerInventory = playerInventory;
        UpdateView();
    }

    private void UpdateView()
    {
        _priceText.text = _inventoryItem.InventoryItemConfig.Price.ToString();
    }
    private void Buy()
    {
        _playerInventory.AddItemByConfigAtFreeSpace(_inventoryItem.InventoryItemConfig);
        Destroy(_inventoryItem.gameObject);
        Hide();
    }
    private void DestroyPopUp()
    {
        Destroy(gameObject);
    }
}
