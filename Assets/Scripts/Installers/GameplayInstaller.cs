using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private PlayerCamera _playerCamera;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private InventoryModel _inventoryModel;
    [SerializeField] private InventoryModel _clothesInventoryModel;
    [SerializeField] private RectTransform _inventoryPoint;
    [SerializeField] private Canvas _canvas;

    public override void InstallBindings()
    {
        BindPlayerInput();
        BindBindPlayerMovement();
        BindInventoryForPlayer();
        BindPlayer();
        BindPlayerCamera();
    }

    private void BindPlayerInput()
    {
        Container
            .BindInterfacesTo<PlayerInput>()
            .AsSingle();
    }
    private void BindBindPlayerMovement()
    {
        Container
            .BindInterfacesTo<PlayerMovement>()
            .AsSingle();
    }
    private void BindPlayer()
    {
        Player player = Container.InstantiatePrefabForComponent<Player>(_playerPrefab, _startPoint.position, Quaternion.identity, null);

        Container
            .Bind<Player>()
            .FromInstance(player)
            .AsSingle();
    }
    private void BindPlayerCamera()
    {
        PlayerCamera playerCamera = Container.InstantiatePrefabForComponent<PlayerCamera>(_playerCamera);

        Container
            .Bind<PlayerCamera>()
            .FromInstance(playerCamera)
            .AsSingle();
    }
    private void BindInventoryForPlayer()
    {
        InventoryModel inventory = Container.InstantiatePrefabForComponent<InventoryModel>(_inventoryModel);
        Container
            .BindInterfacesTo<InventoryModel>()
            .FromInstance(inventory)
            .AsTransient();

        inventory.transform.parent = _canvas.transform;
        inventory.GetComponent<RectTransform>().position = _inventoryPoint.position;

        InventoryModel inventoryModel = Object.Instantiate(_clothesInventoryModel);
        inventoryModel.transform.parent = inventory.transform.GetChild(0);
        inventoryModel.transform.SetSiblingIndex(0);
        inventoryModel.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0.5f);
        inventoryModel.GetComponent<RectTransform>().anchorMax = new Vector2(0, 0.5f);
        inventoryModel.GetComponent<RectTransform>().localPosition = new Vector3(-110, 0, 0);
    }
}
