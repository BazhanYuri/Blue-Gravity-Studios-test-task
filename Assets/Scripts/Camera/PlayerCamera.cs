using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;

    private Player _player;


    [Inject]
    public void Construct(Player player)
    {
        _player = player;
    }

    private void Awake()
    {
        _virtualCamera.Follow = _player.transform;
    }
}
