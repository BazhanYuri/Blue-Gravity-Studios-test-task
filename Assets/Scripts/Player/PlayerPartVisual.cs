using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPartVisual : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private ClothesAnimationContainer _clothesAnimationContainer;
    [SerializeField] private ClothesType _clothesType;

    public ClothesAnimationContainer ClothesAnimationContainer { get => _clothesAnimationContainer; set { _clothesAnimationContainer = value; } }
    public ClothesType ClothesType { get => _clothesType;}

    public void SetNewSpite(Sprite sprite)
    {
        _spriteRenderer.color = new Color32(255, 255, 255, 255);

        _spriteRenderer.sprite = sprite;
    }
    public void SetStandingSprite()
    {
        _spriteRenderer.color = new Color32(255, 255, 255, 255);

        _spriteRenderer.sprite = _clothesAnimationContainer.StandingSprite;
    }
    public void Clean()
    {
        if (_spriteRenderer == null)
        {
            return;
        }
        _spriteRenderer.color = new Color32(255, 255, 255, 0);
    }
}
