using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController
{
    private Player _player;
    private MonoBehaviour _monoBehaviour;
    private IMovement _movement;

    private Direction _currentDirection = Direction.Up;
    private short _animationIndex;

    private IEnumerator _coroutine;

    public PlayerAnimationController(Player player, IMovement movement, MonoBehaviour monoBehaviour)
    {
        _player = player;
        _movement = movement;
        _monoBehaviour = monoBehaviour;
    }
    public void Initialize()
    {
        _movement.PlayerMoved += OnPlayerMoved;
        _player.PlayerInventoryHolder.DressUpdated += OnDressUpdated;
        _player.PlayerInventoryHolder.DressDeleted += OnDressDeleted;
    }
    private void OnPlayerMoved(Vector2 vector2)
    {
        if (vector2.x == 0 && vector2.y == 0)
        {
            for (int i = 0; i < _player.PlayerPartVisual.Length; i++)
            {
                if (_player.PlayerPartVisual[i].ClothesAnimationContainer == null)
                {
                    continue;
                }
                _player.PlayerPartVisual[i].SetStandingSprite();
            }
            return;
        }

        if (Mathf.Abs(vector2.x) > Mathf.Abs(vector2.y))
        {
            if (vector2.x > 0)
            {
                TryParseRunAnimation(Direction.Right);
            }
            else
            {
                TryParseRunAnimation(Direction.Left);
            }
        }
        else
        {
            if (vector2.y > 0)
            {
                TryParseRunAnimation(Direction.Up);
            }
            else
            {
                TryParseRunAnimation(Direction.Down);
            }
        }
    }


    private void TryParseRunAnimation(Direction direction)
    {
        if (_isRunParsing == false)
        {
            _coroutine = ParseRunAnimation(direction);
            _monoBehaviour.StartCoroutine(_coroutine);
            if (_currentDirection != direction)
            {
                _monoBehaviour.StopCoroutine(_coroutine);
                _isRunParsing = false;
            }
            _currentDirection = direction;
        }
    }
    private bool _isRunParsing = false;
    private IEnumerator ParseRunAnimation(Direction direction)
    {
        _isRunParsing = true;
        yield return new WaitForSeconds(0.1f);
        _animationIndex++;

        for (int i = 0; i < _player.PlayerPartVisual.Length; i++)
        {
            if (_player.PlayerPartVisual[i].ClothesAnimationContainer == null)
            {
                continue;
            }
            Sprite[] _sprites = null;
            switch (direction)
            {
                case Direction.Up:
                    _sprites = _player.PlayerPartVisual[i].ClothesAnimationContainer.RunTopSprites;
                    break;
                case Direction.Down:
                    _sprites = _player.PlayerPartVisual[i].ClothesAnimationContainer.RunDownSprites;
                    break;
                case Direction.Left:
                    _sprites = _player.PlayerPartVisual[i].ClothesAnimationContainer.RunLeftSprites;
                    break;
                case Direction.Right:
                    _sprites = _player.PlayerPartVisual[i].ClothesAnimationContainer.RunRightSprites;
                    break;
                default:
                    break;
            }

            if (_animationIndex >= _sprites.Length)
            {
                _animationIndex = 0;
            }

            _player.PlayerPartVisual[i].SetNewSpite(_sprites[_animationIndex]);
        }
        


        _isRunParsing = false;
    }
    private void OnDressUpdated(InventoryClothesItemConfig inventoryClothesItemConfig)
    {
        for (int i = 0; i < _player.PlayerPartVisual.Length; i++)
        {
            if (_player.PlayerPartVisual[i].ClothesType == inventoryClothesItemConfig.ClothesType)
            {
                _player.PlayerPartVisual[i].ClothesAnimationContainer = inventoryClothesItemConfig.ClothesAnimationContainer;
            }
        }
    }
    private void OnDressDeleted(InventoryClothesItemConfig inventoryClothesItemConfig)
    {
        for (int i = 0; i < _player.PlayerPartVisual.Length; i++)
        {
            if (_player.PlayerPartVisual[i].ClothesType == inventoryClothesItemConfig.ClothesType)
            {
                _player.PlayerPartVisual[i].ClothesAnimationContainer = null;
                _player.PlayerPartVisual[i].Clean();
            }
        }
    }
}
