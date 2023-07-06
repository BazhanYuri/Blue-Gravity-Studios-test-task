using UnityEngine;

[CreateAssetMenu]
public class InventoryClothesItemConfig : InventoryItemConfig
{
    [SerializeField] private ClothesType _clothesType;
    [SerializeField] private ClothesAnimationContainer _clothesAnimationContainer;

    public ClothesType ClothesType { get => _clothesType;}
    public ClothesAnimationContainer ClothesAnimationContainer { get => _clothesAnimationContainer;}
}
