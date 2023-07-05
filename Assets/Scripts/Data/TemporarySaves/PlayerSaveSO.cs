using Array2DEditor;
using UnityEngine;

[CreateAssetMenu]
public class PlayerSaveSO : ScriptableObject
{
    [SerializeField] private Array2D<InventoryItemConfig> _items;
}