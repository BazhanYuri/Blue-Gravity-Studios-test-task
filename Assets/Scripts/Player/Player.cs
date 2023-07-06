using System;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private PlayerPartVisual[] _playerPartVisuals;
    [SerializeField] private PlayerSaveSO _playerSaveSO;
    [SerializeField] private ButtonInteractionView _buttonInteractionViewPrefab;

    private PlayerAnimationController _playerAnimationController;
    private PlayerInventoryHolder _playerInventoryHolder;
    private PlayerInteractionsHandler _playerInteractionsHandler;
    private IPlayerMovement _playerMovement;
    private IPlayerInput _playerInput;
    private IInventory _inventory;

    public Rigidbody2D Rigidbody2D { get => _rigidbody2D;}
    public PlayerPartVisual[] PlayerPartVisual { get => _playerPartVisuals;}
    public IInventory Inventory { get => _inventory;}
    public PlayerInventoryHolder PlayerInventoryHolder { get => _playerInventoryHolder;}

    public event Action<Collider2D> PlayerEnteredTriger;
    public event Action<Collider2D> PlayerExitedTriger;


    [Inject]
    public void Construct(IPlayerMovement playerMovement, IPlayerInput playerInput, IInventory inventory)
    {
        _playerMovement = playerMovement;
        _playerInput = playerInput;
        _inventory = inventory;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerEnteredTriger?.Invoke(collision);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerExitedTriger?.Invoke(collision);
    }
    

    private void Awake()
    {
        _playerAnimationController = new PlayerAnimationController(this, _playerMovement, this);
        _playerInventoryHolder = new PlayerInventoryHolder(_inventory, _playerInput);
        _playerInteractionsHandler = new PlayerInteractionsHandler(this, _playerInput , _buttonInteractionViewPrefab);

        _playerMovement.SetPlayer(this);
        _playerAnimationController.Initialize();
        _playerInventoryHolder.Initialize();
        InitializeInventory();
    }
    
    private void Update()
    {
        _playerInventoryHolder.Tick();
    }
    private void InitializeInventory()
    {
        _inventory.Initialize(_playerSaveSO.Items.GridSize.x, _playerSaveSO.Items.GridSize.y);

        for (int i = 0; i < _playerSaveSO.Items.GridSize.x; i++)
        {
            for (int j = 0; j < _playerSaveSO.Items.GridSize.y; j++)
            {
                if (_playerSaveSO.Items.GetCell(i, j) != null)
                {
                    _inventory.AddItemByConfigAt(i, j, _playerSaveSO.Items.GetCell(i, j));
                }
            }
        }   
    }
}
