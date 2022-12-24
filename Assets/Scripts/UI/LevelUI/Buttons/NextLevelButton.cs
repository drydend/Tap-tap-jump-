using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Button))]
public class NextLevelButton : MonoBehaviour, IInteractableUI
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
        GetComponent<Button>().onClick.AddListener(StartNextLevel);
    }

    private void StartNextLevel()
    {
        OnPlayerInteracted?.Invoke();
        _game.StartNextLevel();
    }
}
