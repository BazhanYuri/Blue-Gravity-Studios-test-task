using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemCell : MonoBehaviour,  IDropHandler
{
    [SerializeField] private Image _image;

    private InventoryItem _inventoryItem;

    public static event Action<ItemCell> ItemDroped;
    public static event Action<ItemCell> ItemLeft;


    public bool IsEmpty {
        get
        {
            return _inventoryItem == null;
        }
    }

    public InventoryItem InventoryItem { get => _inventoryItem;}


    public void BlockCell()
    {
        _image.raycastTarget = false;
    }
    public void SetItem(InventoryItem inventoryItem)
    {
        _inventoryItem = inventoryItem;
        _inventoryItem.transform.parent = transform;
        _inventoryItem.transform.localPosition = Vector3.zero;
    }
    public void InvokeItemLeft()
    {
        ItemLeft?.Invoke(this);
    }
    public virtual void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.TryGetComponent(out InventoryItem inventoryItem))
        {
            if (inventoryItem.IsForStore == true)
            {
                return;
            }
            inventoryItem.ItemCell.InvokeItemLeft();

            _inventoryItem = inventoryItem;
            ItemDroped?.Invoke(this);
        }
    }
}
 