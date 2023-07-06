using Array2DEditor;
using UnityEngine;

[CreateAssetMenu]
public class SalesManConfig : ScriptableObject
{
    [SerializeField] private Array2D<InventoryItemConfig> _items;

    public Array2D<InventoryItemConfig> Items { get => _items; }
}
