using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private PlayerPartVisual _playerPartVisual;
    [SerializeField] private PlayerSaveSO _playerSaveSO;

    private PlayerAnimationController _playerAnimationController;
    private PlayerInventoryHolder _playerInventoryHolder;
    private IPlayerMovement _playerMovement;
    private IPlayerInput _playerInput;
    private IInventory _inventory;

    public Rigidbody2D Rigidbody2D { get => _rigidbody2D;}
    public PlayerPartVisual PlayerPartVisual { get => _playerPartVisual;}

    [Inject]
    public void Construct(IPlayerMovement playerMovement, IPlayerInput playerInput, IInventory inventory)
    {
        _playerMovement = playerMovement;
        _playerInput = playerInput;
        _inventory = inventory;
    }

    private void Awake()
    {
        _playerAnimationController = new PlayerAnimationController(this, _playerMovement, this);
        _playerInventoryHolder = new PlayerInventoryHolder(_inventory, _playerInput);

        _playerMovement.SetPlayer(this);
        _playerAnimationController.Initialize();
        _playerInventoryHolder.Initialize();
        _inventory.Initialize(5, 5);
    }

}
