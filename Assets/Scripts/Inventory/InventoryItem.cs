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

    public ItemCell ItemCell { get => _itemCell;}
    public Image IconImage { get => _iconImage;}

    public static event Action<InventoryItem> ItemDragged;
    public static event Action ItemNotDragged;


   

    public void Initialize(InventoryItemConfig inventoryItemConfig, ItemCell itemCell)
    {
        _inventoryItemConfig = inventoryItemConfig;
        _itemCell = itemCell;
        UpdateView();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        ItemDragged?.Invoke(this);
    }

    public void OnDrag(PointerEventData eventData)
    {
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        ItemNotDragged?.Invoke();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _iconImage.transform.DOScale(1.1f, 0.1f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _iconImage.transform.DOScale(1.0f, 0.1f);
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
