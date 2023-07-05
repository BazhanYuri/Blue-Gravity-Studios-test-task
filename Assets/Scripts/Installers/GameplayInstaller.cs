using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private PlayerCamera _playerCamera;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private InventoryModel _inventoryModel;
    [SerializeField] private Canvas _canvas;

    public override void InstallBindings()
    {
        BindPlayerInput();
        BindBindPlayerMovement();
        BindInventory();
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
    private void BindInventory()
    {
        InventoryModel inventory = Container.InstantiatePrefabForComponent<InventoryModel>(_inventoryModel);
        Container
            .BindInterfacesTo<InventoryModel>()
            .FromInstance(inventory)
            .AsTransient();

        inventory.transform.parent = _canvas.transform;
        inventory.transform.localPosition = Vector3.zero;
    }
}
