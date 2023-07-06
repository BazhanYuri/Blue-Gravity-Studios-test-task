using UnityEngine;

[CreateAssetMenu]
public class ClothesAnimationContainer : ScriptableObject
{
    [SerializeField] private Sprite _standingSprite;
    [SerializeField] private Sprite[] _runLeftSprites;
    [SerializeField] private Sprite[] _runRightSprites;

    [SerializeField] private Sprite[] _runTopSprites;
    [SerializeField] private Sprite[] _runDownSprites;

    public Sprite[] RunLeftSprites { get => _runLeftSprites; }
    public Sprite[] RunRightSprites { get => _runRightSprites; }
    public Sprite[] RunTopSprites { get => _runTopSprites; }
    public Sprite[] RunDownSprites { get => _runDownSprites; }
    public Sprite StandingSprite { get => _standingSprite;}
}
