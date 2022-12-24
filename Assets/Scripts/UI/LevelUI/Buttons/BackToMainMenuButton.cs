using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Button))]
public class BackToMainMenuButton : MonoBehaviour, IInteractableUI
{
    private Game _game;

    public event Action OnPlayerInteracted;

    [Inject]
    public void Construct(Game game)
    {
        _game = game;
    }

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(LoadMainMenu);
    }

    private void LoadMainMenu()
    {
        OnPlayerInteracted?.Invoke();
        _game.LoadMainMenu();
    }
}
