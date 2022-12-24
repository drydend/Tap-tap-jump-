using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Button))]
public class PlayLastUnlockedLevelButton : MonoBehaviour, IInteractableUI
{
    public event Action OnPlayerInteracted;

    private Game _game;

    [Inject]
    public void Construct(Game game)
    {
        _game = game;
        GetComponent<Button>().onClick.AddListener(Play);
    }
    private void Play()
    {
        OnPlayerInteracted?.Invoke();
        _game.PlayLevel(_game.LastUnlockedLevel);
    }

}
