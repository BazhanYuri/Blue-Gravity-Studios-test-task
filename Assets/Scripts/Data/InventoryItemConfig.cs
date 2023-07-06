using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class InventoryItemConfig : ScriptableObject
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private int _price;

    public Sprite Icon { get => _icon;}
    public int Price { get => _price;}
}
