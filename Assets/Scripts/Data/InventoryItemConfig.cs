using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class InventoryItemConfig : ScriptableObject
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private int _price;
}
