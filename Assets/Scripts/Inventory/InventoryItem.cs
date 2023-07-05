using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IPointerEnterHandler
{
    private InventoryItemConfig _inventoryItemConfig;

    private bool _isDragging;

    public void OnPointerEnter(PointerEventData eventData)
    {
        _isDragging = true;
    }
    public void SetData(InventoryItemConfig inventoryItemConfig)
    {
        _inventoryItemConfig = inventoryItemConfig;
    }
}
