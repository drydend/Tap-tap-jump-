using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Button))]
public class StartCurrentLevelButton : MonoBehaviour, IInteractableUI
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
        GetComponent<Button>().onClick.AddListener(StartCurrentLevel);
    }

    private void StartCurrentLevel()
    {
        OnPlayerInteracted?.Invoke();
        _game.StartCurrentLevel();
    }
}
