using UnityEngine;
using UnityEngine.EventSystems;

public class ItemClothesCell : ItemCell
{
    [SerializeField] private ClothesType _clothesType;



    public override void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.TryGetComponent(out InventoryItem inventoryItem))
        {
            if (inventoryItem.InventoryItemConfig is InventoryClothesItemConfig clothesItemConfig)
            {
                if (clothesItemConfig.ClothesType != _clothesType)
                {
                    return;
                }
                base.OnDrop(eventData);
            }
        }
    }
}
