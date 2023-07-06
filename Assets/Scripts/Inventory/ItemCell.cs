using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class ItemCell : MonoBehaviour,  IDropHandler
{
    private InventoryItem _inventoryItem;

    public static event Action<ItemCell> ItemDroped;


    public bool IsEmpty {
        get
        {
            return _inventoryItem == null;
        }
    }


    
    public void SetItem(InventoryItem inventoryItem)
    {
        _inventoryItem = inventoryItem;
        _inventoryItem.transform.parent = transform;
        _inventoryItem.transform.localPosition = Vector3.zero;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            ItemDroped?.Invoke(this);
        }
    }
}
