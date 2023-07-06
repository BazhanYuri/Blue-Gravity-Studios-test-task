using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class InventoryItem : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerExitHandler, IPointerEnterHandler
{
    [SerializeField] private Image _iconImage;
    [SerializeField] private CanvasGroup canvasGroup;

    private InventoryItemConfig _inventoryItemConfig;
    private ItemCell _itemCell;
    private bool _isForStore = false;

    public ItemCell ItemCell { get => _itemCell;}
    public Image IconImage { get => _iconImage;}
    public bool IsForStore { get => _isForStore;}
    public InventoryItemConfig InventoryItemConfig { get => _inventoryItemConfig;}

    public static event Action<InventoryItem> ItemDragged;
    public static event Action ItemNotDragged;
    public static event Action<InventoryItem> ItemClicked;




    public void Initialize(InventoryItemConfig inventoryItemConfig, ItemCell itemCell)
    {
        _inventoryItemConfig = inventoryItemConfig;
        _itemCell = itemCell;
        UpdateView();
    }

    
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (_isForStore)
        {
            return;
        }
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        ItemDragged?.Invoke(this);
    }

    public void OnDrag(PointerEventData eventData)
    {
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (_isForStore)
        {
            return;
        }
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        ItemNotDragged?.Invoke();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_isForStore == true)
        {
            ItemClicked?.Invoke(this);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _iconImage.transform.DOScale(1.1f, 0.1f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _iconImage.transform.DOScale(1.0f, 0.1f);
    }
    public void SetAsForStore()
    {
        _isForStore = true;
    }
    public void SetCell(ItemCell itemCell)
    {
        _itemCell = itemCell;
    }
    private void UpdateView()
    {
        _iconImage.sprite = _inventoryItemConfig.Icon;
    }
}
