using UnityEngine;

public class PlayerInteractionsHandler
{
    private ButtonInteractionView _buttonInteractionViewPrefab;


    private ButtonInteractionView _currentButton;

    private IInteractable _interactable;


    public PlayerInteractionsHandler(Player player, IPlayerInput playerInput, ButtonInteractionView buttonInteractionViewPrefab)
    {
        _buttonInteractionViewPrefab = buttonInteractionViewPrefab;
        player.PlayerEnteredTriger += OnPlayerEnteredTrigger;
        player.PlayerExitedTriger += OnPlayerExitedTriger;
        playerInput.InteractButtonPressed += TryInteract;
    }
    private void OnPlayerEnteredTrigger(Collider2D collider)
    {
        if (collider.TryGetComponent(out SalesMan salesMan))
        {
            _currentButton = Object.Instantiate(_buttonInteractionViewPrefab);
            _currentButton.transform.position = salesMan.transform.position + new Vector3(0.5f, 0.5f, 0);
            _interactable = salesMan;
        }
    }
    private void OnPlayerExitedTriger(Collider2D collider)
    {
        if (collider.TryGetComponent(out SalesMan salesMan))
        {
            Undo();

            _currentButton.Hide();
            _interactable = null;
        }
    }
    private void TryInteract()
    {
        _interactable?.Action();
    }
    private void Undo()
    {
        _interactable?.Undo();
    }
}
