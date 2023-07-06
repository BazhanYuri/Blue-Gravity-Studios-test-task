using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyItemPopUp : PopUpWindow
{
    [SerializeField] private Button _buyButton;
    [SerializeField] private TextMeshProUGUI _priceText;

    private InventoryItemConfig _inventoryItemConfig;


    private void OnEnable()
    {
        _buyButton.onClick.AddListener(Buy);
    }
    private void OnDisable()
    {
        _buyButton.onClick.RemoveListener(Buy);
    }

    public void Initialize(InventoryItemConfig inventoryItemConfig)
    {
        _inventoryItemConfig = inventoryItemConfig;
        UpdateView();
    }    

    private void UpdateView()
    {
        _priceText.text = _inventoryItemConfig.Price.ToString();
    }
    private void Buy()
    {
        Debug.Log("Bought");
    }
}
