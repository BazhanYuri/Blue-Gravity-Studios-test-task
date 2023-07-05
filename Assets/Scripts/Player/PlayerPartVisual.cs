using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPartVisual : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;

    [SerializeField] private Sprite _standingSprite;
    [SerializeField] private Sprite[] _runLeftSprites;
    [SerializeField] private Sprite[] _runRightSprites;

    [SerializeField] private Sprite[] _runTopSprites;
    [SerializeField] private Sprite[] _runDownSprites;

    public Sprite[] RunLeftSprites { get => _runLeftSprites;}
    public Sprite[] RunRightSprites { get => _runRightSprites;}
    public Sprite[] RunTopSprites { get => _runTopSprites;}
    public Sprite[] RunDownSprites { get => _runDownSprites;}



    public void SetNewSpite(Sprite sprite)
    {
        _spriteRenderer.sprite = sprite;
    }
    public void SetStandingSprite()
    {
        _spriteRenderer.sprite = _standingSprite;
    }
}
