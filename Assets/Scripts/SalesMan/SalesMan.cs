using UnityEngine;
using Zenject;

public class SalesMan : MonoBehaviour, IInteractable
{
    [SerializeField] private SalesManInventoryModel _inventoryModelPrefab;
    [SerializeField] private BuyItemPopUp _buyItemPopUpPrefab;
    [SerializeField] private RectTransform _inventoryStorePoint;
    [SerializeField] private SalesManConfig _salesManConfig;

    private Player _player;
    private IInventory _inventory;

    private BuyItemPopUp _buyItemPopUp;



    [Inject]
    public void Construct(Player player)
    {
        _player = player;
    }
    private void OnEnable()
    {
        InventoryItem.ItemClicked += OnItemClicked;
    }
    private void OnDisable()
    {
        InventoryItem.ItemClicked -= OnItemClicked;
    }
    public void Action()
    {
        _player.Inventory.ShowInventory();
        _player.Inventory.BlockClose();
        if (_inventory != null)
        {
            _inventory.ShowInventory();
            return;
        }

        SalesManInventoryModel inventoryModel = Instantiate(_inventoryModelPrefab, _inventoryStorePoint.position, Quaternion.identity);
        inventoryModel.transform.parent = _inventoryStorePoint.transform.parent;
        inventoryModel.GetComponent<RectTransform>().position = _inventoryStorePoint.position;

        _inventory = inventoryModel;


        InitializeInventory();
        inventoryModel.BlockAllItems();

    }

    public void Undo()
    {
        _inventory?.HideInventory();
        _player.Inventory.HideInventory();
        _player.Inventory.UnBlockCloose();
    }

    private void InitializeInventory()
    {
        _inventory.Initialize(_salesManConfig.Items.GridSize.x, _salesManConfig.Items.GridSize.y);

        for (int i = 0; i < _salesManConfig.Items.GridSize.x; i++)
        {
            for (int j = 0; j < _salesManConfig.Items.GridSize.y; j++)
            {
                if (_salesManConfig.Items.GetCell(i, j) != null)
                {
                    _inventory.AddItemByConfigAt(i, j, _salesManConfig.Items.GetCell(i, j));
                }
            }
        }
    }
    private void OnItemClicked(InventoryItem inventoryItem)
    {
        if (_buyItemPopUp != null)
        {
            Destroy(_buyItemPopUp.gameObject);
        }
        _buyItemPopUp = Instantiate(_buyItemPopUpPrefab);
        _buyItemPopUp.transform.parent = inventoryItem.transform.parent;

        _buyItemPopUp.Initialize(inventoryItem, _player.Inventory);
        _buyItemPopUp.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0);
        _buyItemPopUp.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0);
        _buyItemPopUp.GetComponent<RectTransform>().localPosition = Vector3.zero;
    }
}
