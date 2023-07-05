using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCell : MonoBehaviour
{
    private InventoryItem _inventoryItem;


    public bool IsEmpty {
        get
        {
            return _inventoryItem == null;
        }
    }
    


    public void SetItem(InventoryItem inventoryItem)
    {
        _inventoryItem = inventoryItem;
    }
}
