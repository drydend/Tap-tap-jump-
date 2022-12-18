using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Button))]
public class StartCurrentLevelButton : MonoBehaviour
{
    private Game _game;

    [Inject]
    public void Construct(Game game)
    {
        _game = game;
    }

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(_game.StartCurrentLevel);
    }
}
