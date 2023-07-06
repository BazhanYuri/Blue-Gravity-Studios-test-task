using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryView : PopUpWindow
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private Transform _contentRoot;

    public Transform ContentRoot { get => _contentRoot;}
    public Button CloseButton { get => _closeButton;}

    private void OnEnable()
    {
        _closeButton.onClick.AddListener(Hide);
    }
    private void OnDisable()
    {
        _closeButton.onClick.RemoveListener(Hide);
    }
}
